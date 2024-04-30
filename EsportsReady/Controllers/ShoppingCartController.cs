using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Authorization;

namespace EsportsReady.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        public ShoppingCartController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult AddToCart(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var productToAdd = _context.Products.FirstOrDefault(p => p.Id == id);

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
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var cartViewModel = new ShoppingCartViewModel()
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity),
                TotalQuantity = cartItems.Count()
            };

            return View(cartViewModel);
        }

        public IActionResult RemoveItem(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == id);

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

        public IActionResult RemoveAll(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? [];

            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == id);

            cartItems.RemoveAll(item => item == itemToRemove);

            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }
    }
}
