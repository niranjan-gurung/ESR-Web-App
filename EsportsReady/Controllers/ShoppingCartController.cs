using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EsportsReady.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        //private List<ShoppingCartItem> _cartItems;
        public ShoppingCartController(ShopContext context)
        {
            _context = context;
            //_cartItems = new List<ShoppingCartItem>();
        }

        public IActionResult AddToCart(int id)
        {
            var productToAdd = _context.Products.FirstOrDefault(p => p.Id == id);

            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingCartItem = cartItems.FirstOrDefault(item => item.Product.Id == id);

            // if item already exists in cart, then increment amount:
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem 
                { 
                    Product = productToAdd, 
                    Quantity = 1 
                });
            }

            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartViewModel = new ShoppingCartViewModel()
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity)
            };

            return View(cartViewModel);
        }

        public IActionResult RemoveItem(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == id);

            // if item already exists in cart, then increment amount:
            if (itemToRemove  != null)
            {
                if (itemToRemove.Quantity > 1)
                    itemToRemove.Quantity -= 1;
                else
                    cartItems.Remove(itemToRemove);
            }

            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }
    }
}
