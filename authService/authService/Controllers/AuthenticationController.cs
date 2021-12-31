using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using authService.Models;
using authService.Context;
using authService.Security;

namespace authService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private IConfiguration _config;
        private UserContext _userContext;

        public AuthenticationController(IConfiguration config, UserContext userContext)
        {
            _config = config;
            _userContext = userContext;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        /// <summary>
        /// niet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Test()
        {
            return "wokkels zijn lekker";
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
            User user = null;

            //get all users to loop through
            IEnumerable<User> users = _userContext.Users;

            foreach (User val in users)
            {
                if (val.UserName == login.UserName) //username match?
                {
                    if (SecurePasswordHasher.Verify(login.Password, val.Password)) //password match with security?
                    {
                        return val;
                    }
                }
            }
            //return null if no match can be found
            return null;

        }
    }
}
