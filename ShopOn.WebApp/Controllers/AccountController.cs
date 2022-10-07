using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopOn.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Controllers
{
    public class AccountController : Controller
    {
        //user manager-for register new user
        //signin manager-login/logout

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
            
        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
         
            //server-side validation
            if (ModelState.IsValid)
            {
                //create identityuser -> copying data from register
                var user = new IdentityUser() { UserName = register.LoginId, Email = register.LoginId };
                var result = await userManager.CreateAsync(user, register.Password);

                if (result.Succeeded)
                {
                    //consider user as logged in
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //redirect to home
                    return RedirectToAction("Index","Home");
                }

                //to handle any error that may occur
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.LoginId, user.Password, user.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid loginid or password");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
