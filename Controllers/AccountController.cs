using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginIdentityUser.Data;
using LoginIdentityUser.Helpers;
using LoginIdentityUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LoginIdentityUser.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public AccountController(DataContext dataContext,
            IConfiguration configuration,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Controller", "action");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrecta.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return this.RedirectToAction("Login", "Login");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.AddUser(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "El email esta en uso.");
                    return View(model);

                }

                await _dataContext.SaveChangesAsync();

                ViewBag.Message = "Usuario Regitrado exitosamente";

                return View();
            }
            return RedirectToAction("Login", "Login");
        }
    }
}