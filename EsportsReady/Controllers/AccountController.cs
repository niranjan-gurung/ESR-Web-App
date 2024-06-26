using EsportsReady.Data;
using EsportsReady.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EsportsReady.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid) 
            { 
                var user = new IdentityUser 
                { 
                    UserName = model.Email, 
                    Email = model.Email,
                };
                
                // creates new user account with the details from model object:
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) 
                {
                    var _token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", 
                        new { userId = user.Id, token = _token }, Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirm your account",
                        "Please confirm your account by clicking <a href=\"" + 
                        confirmationLink + "\">here</a>");

                    /* every new user is given 'User' role by default.
                     * admin role was assigned manually... */
                    await _userManager.AddToRoleAsync(user, "User");

                    return View("ConfirmEmail");

                    // sign in after successful register:
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError err in result.Errors)
                    ModelState.AddModelError("", err.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View();
            //return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, 
                    model.Password, 
                    model.RememberMe, 
                    false);

                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ViewBag.errorMessage = "You must have a confirmed email to log on.";
                        return NotFound();
                    }
                }

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);
                    else if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        return RedirectToAction("ListAll", "Product");
                    else 
                        return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            // remove all instance of 'Cart' key from session on logout:
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index", "Home");
        }
    }
}
