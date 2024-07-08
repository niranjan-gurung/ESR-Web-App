using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace EsportsReady.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ShopContext _context;
        public CheckoutController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var domain = "https://localhost:7050/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "Checkout/OrderConfirmation",
                CancelUrl = domain + "Account/Login",
                //UiMode = "embedded",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                //ReturnUrl = domain + "/return.html?session_id={CHECKOUT_SESSION_ID}",
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

            //return View(cartItems);
            return new StatusCodeResult(303);
        }

        public async Task<IActionResult> OrderConfirmation()
        {
            return View();
        }
    }
}
