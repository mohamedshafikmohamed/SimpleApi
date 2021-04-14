using api2.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    
        private UserRepos _userService;
         private IMailService _mailService;
        private IConfiguration _configuration;
        UserManager<IdentityUser> _usermanager;
        public UserController(UserRepos userService,  IConfiguration configuration,UserManager<IdentityUser> usermanager, IMailService mailService)
        {
            _userService = userService;
           _mailService = mailService;
            _configuration = configuration;
            _usermanager = usermanager;
        }

        // /api/User/Search
        [HttpGet("Search")]
        public async Task<IActionResult> SearchForProject(string title ,string email)
        {
            if (title!=null&& email !=null)
            {
                var result = _userService.SearchForProject(title, email);

               
                    return Ok(result); // Status Code: 200 

               
            }

            return BadRequest("Some properties are not valid");
        }
        
        // /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        // /api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
        [HttpGet("GetProfile")]

        public async Task<IActionResult> GetProfile( )
        {

            string u = User.Claims.First(c => c.Type == "UserId").Value;
            var x =  _userService.GetUser(u);
            return Ok(x.Email);


        }

        // /api/user/confirmemail?userid&token
       [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
      {
          if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
              return NotFound();

          var result = await _userService.ConfirmEmailAsync(userId, token);

          if (result.IsSuccess)
          {
              return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
          }

          return BadRequest(result);
      }
    
        // api/auth/forgetpassword
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
           // email = "mohamed.shafik@m-eight.com";
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _userService.ForgetPasswordAsync(email);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }


    }
}