using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Admin.Models;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Admin.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IAccountService _service;

        public AuthController(IAccountService service)
        {
            _service = service;
        }


        [Route("Account/LogIn")]
        [Route("Auth/LogIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel account)
        {
            if (ModelState.IsValid)
            {
                var isRegistered = await _service.AdminAndModeratorLogIn(account.UserName, account.Password);
                var role = await _service.GetRoleAsync(account.UserName);

                if (isRegistered)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(account);
        }

        [Route("Account/LogIn")]
        [Route("Auth/LogIn")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        public async Task<IActionResult> LogOut(string accId)
        {
            await _service.LogOutAsync(accId);

            return RedirectToAction("LogIn");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
