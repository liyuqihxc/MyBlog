using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MyBlog.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class AuthController : Controller
    {
        private IConfiguration Configuration { get; }

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, "Nitya Prakash Sharma")
            };

            var key = new SymmetricSecurityKey(Guid.Parse(Configuration["Token:IssuerSigningKey"]).ToByteArray());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
            );

            return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token), expires_on = DateTime.Now.AddDays(5) });
            //return BadRequest("Could not create token");
        }

        [HttpPost("signup")]
        public IActionResult SignUp(string username, string password)
        {
            return Ok();
        }
    }
}
