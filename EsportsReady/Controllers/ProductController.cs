using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GamingPCs()
        {
            return View(_context.Products.ToList());
        }

        // GET/id: return specific gaming pc (id based)
        public IActionResult GamingPC(int? id) 
        {
            if (id == null || id == 0)
                return NotFound();

            Product? product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
