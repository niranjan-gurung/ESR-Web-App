using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stripe;
using Stripe.Checkout;

namespace EsportsReady.Controllers
{
    public class CheckoutController : Controller
    {
        public async Task<IActionResult> Charge()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var domain = "https://localhost:7050/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "Checkout/Success",
                CancelUrl = domain + "ShoppingCart/ViewCart",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
            };

            foreach (var item in cartItems) 
            {
                var sessionListItems = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)item.Product.Price * 100,
                        Currency = "gbp",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Title
                        }
                    },
                    Quantity = item.Quantity
                };
                options.LineItems.Add(sessionListItems);
            }

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> Success()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];
            cartItems.Clear();
            HttpContext.Session.Set("Cart", cartItems);

            return View();
        }
    }
}
