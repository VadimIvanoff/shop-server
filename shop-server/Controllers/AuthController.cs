using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shop_server.Data;
using shop_server.Models;

namespace shop_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(ApplicationDbContext context,
                                 UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IConfiguration configuration,
                                 SignInManager<IdentityUser> signInManager) : base(context, userManager, roleManager, configuration)
        {
            _signInManager = signInManager;
        }
        // GET: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByEmailAsync(login.Email);
                    return Ok(new User { Name = user.UserName});
                }

            }
            return BadRequest("Не верное имя пользователя или пароль");
        }

        // GET: api/Auth/logout
        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]NewUser newUser)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser { Email = newUser.Email, UserName = newUser.Email };
                var result = await UserManager.CreateAsync(identityUser, newUser.Password);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByEmailAsync(newUser.Email);
                    return Ok(new User { Name = user.UserName });
                }
               foreach(var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
            }
            return BadRequest(errors.ToArray());
        }

      
    }
}
