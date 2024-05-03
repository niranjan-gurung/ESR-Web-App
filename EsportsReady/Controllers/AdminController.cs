using EsportsReady.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EsportsReady.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole model)
        {
            if (ModelState.IsValid) 
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError err in result.Errors)
                    ModelState.AddModelError("", err.Description);
            }

            return View(model);
        }

        /* TODO: 
         * 
         * Admin dashboard - allows for CRUD operations of products.
         * views will mostly stay the same so use partial views??
         */
    }
}
