using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using MyBlog.App;
using Microsoft.Extensions.Caching.Memory;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class AuthController : Controller
    {
        private IConfiguration _Configuration { get; }
        private AuthApp _AuthApp { get; }
        private IMemoryCache _MemoryCache;

        public AuthController(IConfiguration configuration, AuthApp authApp, IMemoryCache memoryCache)
        {
            _Configuration = configuration;
            _AuthApp = authApp;
            _MemoryCache = memoryCache;
        }

        // GET: api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginModel Params)
        {
            var user = await _AuthApp.Verify(Params.username, Params.password);
            if (user == null)
                return Ok(new { access_token = "", expires_on = "" });

            IEnumerable<Claim> claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, user.SecurityStamp),
                new Claim(JwtRegisteredClaimNames.GivenName, user.NickName)
            };

            var key = new SymmetricSecurityKey(Guid.Parse(_Configuration["Token.IssuerSigningKey"]).ToByteArray());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _Configuration["Token:Issuer"],
                audience: _Configuration["Token:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: creds
            );

            return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token), expires_on = DateTime.Now.AddDays(5) });
        }

        [HttpPost("signup")]
        public IActionResult SignUp(string username, string password)
        {
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
