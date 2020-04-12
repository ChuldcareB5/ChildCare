using ChildCare.MonitoringSystem.Business;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ChildCare.MonitoringSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBusiness userBusiness;

        public AccountController(UserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = this.userBusiness.GetUser(loginViewModel.UserName, loginViewModel.Password);

                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                            new Claim(ClaimTypes.Role, user.Role.RoleId.ToString())
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

					
                        await HttpContext.SignInAsync(principal);
						if (user.Role.RoleId == 2)
						{
                            return RedirectToAction("Index", "User");
                           
						}
						else
						{
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(LoginViewModel.ErrorMessage), "Invalid user name or password!");
                    }
                }
                else
                {
					//ModelState.AddModelError(nameof(LoginViewModel.ErrorMessage), "Invalid user name or password!");
					return RedirectToAction("Index", "Home");
                }
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.Now,
                IsPersistent = false
            });

            return RedirectToAction("LogIn", "Account");
        }

        public ActionResult<Boolean> ChangePassword(UserModel userModel)
        {
            var user = this.userBusiness.ChangePassword(userModel);
            return user;
        }

    }
}