using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PerfectPolicies.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPolicies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly PerfectPoliciesContext _context;

        #region Config
        public TokenController(IConfiguration config, PerfectPoliciesContext context)
        {
            _config = config;
            _context = context;
        }
        #endregion

        #region Public Endpoints
        /// <summary>
        /// Generate a token for an existing user
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.UserName, _userData.Password);

                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new Claim[] {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _config["JWT:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoId.ToString()),

                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin"),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };

                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _config["JWT:Issuer"],
                        _config["JWT:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// get user from database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user if found otherwise return null</returns>

        private UserInfo GetUser(string username, string password)
        {
            var user = _context.Users.Where(c => c.UserName.Equals(username)).FirstOrDefault();

            if (user != null && user.Password.Equals(password))
            {
                return user;
            }

            return null;
        }

        #endregion
    }
}
