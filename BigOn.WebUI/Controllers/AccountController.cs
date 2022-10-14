using BigOn.Domain.Models.Entities.Membership;
using BigOn.Domain.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BigOn.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<BigOnUser> signInManager;
        private readonly UserManager<BigOnUser> userManager;

        public AccountController(SignInManager<BigOnUser> signInManager, 
            UserManager<BigOnUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/signin.html")]
        public async Task<IActionResult> Signin(UserFormModel model)
        {
            if (!model.IsValid())
                goto end;   

            var user = await userManager.FindByEmailAsync(model.Username);

            if (user == null)
            {  
                ModelState.AddModelError("Username", "Invalid email or password!");
                goto end;   
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("Username", "You are not allowed to enter!");
                goto end;
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("Username", "Try after 5 minutes!");
                goto end;
            }

            var redirectedUrl = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(redirectedUrl))
            {
                return Redirect(redirectedUrl); 
            }

            return RedirectToAction("Index", "Home");

        end: 
            return View(model);
        }
    }
}
