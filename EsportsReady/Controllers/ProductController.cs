using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsportsReady.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: return All Gaming pcs
        public async Task<IActionResult> GamingPCs()
        {
            // grabs all products and its description from DB, through FK link.
            List<Product> products = await _context.Products.Include(d => d.Description).ToListAsync();
            return View(products);
        }

        // GET/id: return specific gaming pc (id based)
        public async Task<IActionResult> GamingPC(int? id) 
        {
            if (id == null || id == 0)
                return NotFound();

            // grabs ID specific product and its description from DB, through FK link.
            Product? product = await _context.Products
                .Include(d => d.Description)
                .SingleOrDefaultAsync(d => d.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
