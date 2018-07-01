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
using MyBlog.Common;
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
            var user = await _AuthApp.Verify(Params.UserName, Params.Password);
            if (user == null)
                return Challenge();

            var timeNow = DateTime.UtcNow;

            /*iss(Issuser)：代表这个JWT的签发主体；
            sub(Subject)：代表这个JWT的主体，即它的所有人；
            aud(Audience)：代表这个JWT的接收对象；
            exp(Expiration time)：是一个时间戳，代表这个JWT的过期时间；
            nbf(Not Before)：是一个时间戳，代表这个JWT生效的开始时间，意味着在这个时间之前验证JWT是会失败的；
            iat(Issued at)：是一个时间戳，代表这个JWT的签发时间；
            jti(JWT ID)：是JWT的唯一标识。*/
            IEnumerable<Claim> claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, user.SecurityStamp),
                new Claim(JwtRegisteredClaimNames.Iat, timeNow.ToUnixTimestamp().ToString(), ClaimValueTypes.Integer64),
            };

            var key = new SymmetricSecurityKey(Guid.Parse(_Configuration["Token.IssuerSigningKey"]).ToByteArray());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _Configuration["Token:Issuer"],
                audience: _Configuration["Token:Audience"],
                claims: claims,
                notBefore: timeNow,
                expires: timeNow.AddDays(5),
                signingCredentials: creds
            );

            return Ok(new {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_on = DateTime.Now.AddDays(5),
                nick_name = user.NickName
            });
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
