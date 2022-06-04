using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Domain.POCO;
using MovieManagement.Service.Abstractions;
using MovieManagement.Service.Models;
using MovieManagement.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _service;

        public AccountController(UserManager<Account> accountManager, SignInManager<Account> signInManager, RoleManager<IdentityRole> roleManager, IAccountService service)
        {
            _userManager = accountManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _service = service;
        }

        //public AccountController(IAccountService service)
        //{
        //    _service = service;
        //}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserRequest account)
        {
           
            
            await _service.RegisterAccountAsync(account.Adapt<AccountServiceModel>(), true);


            return Ok();
        }

        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInAccountRequest request)
        {
            var token = await _service.AuthenticateAsync(request.UserName, request.Password);

            return Ok(token);
        }
    }
}
