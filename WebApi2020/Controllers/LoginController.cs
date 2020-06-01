using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi2020.DB;
using WebApi2020.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi2020.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtSettings setting;
        private readonly MyContext db;

        public LoginController(IOptions<JwtSettings> options, MyContext context)
        {
            setting = options.Value;
            db = context;
        }

        [HttpPost]
        public IActionResult SignIn(JwtLoginInfo mode)
        {
            if (mode.Name == "aaa" && mode.Password == "abc123")
            {
                List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, mode.Name)
                    };
                List<ClaimsIdentity> claimsIdentitys = new List<ClaimsIdentity>
                    {
                        new ClaimsIdentity(claims,"SysUser")
                    };
                ClaimsPrincipal p = new ClaimsPrincipal(claimsIdentitys);
                var claimsIdentity = p.Identities.First(x => x.AuthenticationType == "SysUser");
                var name = claimsIdentity.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                //var symmetricKey = Convert.FromBase64String(mode.Password);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Secret));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(setting.Issuer, setting.Audience, claims, DateTime.Now, DateTime.Now.AddDays(1), signingCredentials);
                var tokenHandler = new JwtSecurityTokenHandler();
                string Token = tokenHandler.WriteToken(token);
                return Ok(new { token = Token });
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult GetToken(JwtLoginInfo info)
        {
            var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,"some_id"),
                        new Claim(JwtRegisteredClaimNames.UniqueName,info.Name),
                        new Claim("granny","cookie"),
                    };
            var secretBytes = Encoding.UTF8.GetBytes(setting.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: setting.Issuer, audience: setting.Audience, claims, notBefore: DateTime.Now, expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            string Token = tokenHandler.WriteToken(token);
            return Ok(new { token = Token });
        }
    }
}
