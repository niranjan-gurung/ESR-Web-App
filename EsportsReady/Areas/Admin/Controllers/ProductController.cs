using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Authorization;

namespace EsportsReady.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ShopContext _context;
        public ProductController(ShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListAll", "Product", new { area = "User" });
            }
            return View(product);
        }

        // GET: Admin/Product/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // currently working, but not sure if its most effective solution...
                    // makes sure that product.id && description.id is always the same:
                    product.Description.DescriptionId = product.Id;
                    product.Description.ProductId = product.Id;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListAll", "Product", new { area = "User" });
            }
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            // check if the product has been added to cart:
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart");
            var existingCartItem = 
                cartItems.FirstOrDefault(item => item.Product.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);

                if (existingCartItem != null) 
                {
                    // deleting product removes it from cart also:
                    cartItems.RemoveAll(item => item == existingCartItem);
                }
            }

            HttpContext.Session.Set("Cart", cartItems);

            await _context.SaveChangesAsync();
            return RedirectToAction("ListAll", "Product", new { area = "User" });
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
