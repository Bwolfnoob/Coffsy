using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Coffsy.Application.ViewModels;
using Coffsy.Application.Entity;
using Coffsy.Application.Interfaces;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace Coffsy.Presentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserAppService userService;

        public LoginController(IUserAppService _userService)
        {
            userService = _userService;
        }
      
        public IActionResult Login(string returnUrl = null)
        {
        //    ViewData["ReturnUrl"] = returnUrl;

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl = null)
        {
       //     ViewData["ReturnUrl"] = returnUrl;

            try
            {
             
                userService.Login(user);
                await HttpContext.Authentication.SignInAsync("Cookies",
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> { new Claim("sub", user.Name) }, "local", "sub", "role")));
                return RedirectToLocal(returnUrl);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(user);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
