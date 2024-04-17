using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EsportsReady.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        private readonly List<ShoppingCartItem> _cartItems;
        public ShoppingCartController(ShopContext context)
        {
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }

        public IActionResult AddToCart(int id)
        {
            var productToAdd = _context.Products.FirstOrDefault(p => p.Id == id);

            var existingCartItem = _cartItems.FirstOrDefault(item => item.Product.Id == id);

            // if item already exists in cart, then increment amount:
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
            }
            else
            {
                _cartItems.Add(new ShoppingCartItem 
                { 
                    Product = productToAdd, 
                    Quantity = 1 
                });
            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartViewModel = new ShoppingCartViewModel()
            {
                CartItems = _cartItems,
                TotalPrice = _cartItems.Sum(item => item.Product.Price * item.Quantity)
            };

            return View(cartViewModel);
        }
    }
}
