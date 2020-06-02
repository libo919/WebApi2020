using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi2020.Models.AuthModels;

namespace WebApi2020.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApiUserController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly List<ApiUser> _apiUsers;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jwtSettings"></param>
        /// <param name="apiUsers"></param>
        public ApiUserController(IOptions<JwtSettings> jwtSettings, IOptions<List<ApiUser>> apiUsers)
        {
            _jwtSettings = jwtSettings.Value;
            _apiUsers = apiUsers.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Token(ApiUser user)
        {
            var apiuser = _apiUsers.SingleOrDefault(x => x.UID == user.UID);

            if (apiuser == null)
            {
                return NotFound("用户不存在");
            }
            if (apiuser.Secret != user.Secret)
            {
                return BadRequest("密钥不匹配");
            }
            DateTime now = DateTime.UtcNow;
            List<Claim> claims = new List<Claim>
                    {
                        new Claim("Name", apiuser.Name),
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, DateTime.Now, DateTime.Now.AddDays(1), signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            string Token = tokenHandler.WriteToken(token);
            return Ok(new { token = Token });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ReToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string authorization = Request.Headers["Authorization"];
                string[] auths = authorization.Split(" ");
                string[] arr = auths[1].Split(".");

                JwtSecurityToken tk = tokenHandler.ReadJwtToken(auths[1]);
                var exp = Convert.ToInt64(tk.Payload["exp"]);
                var nbf = Convert.ToInt64(tk.Payload["nbf"]);
                string name = tk.Payload["Name"].ToString();
                DateTime dt0 = new DateTime(1970, 1, 1, 0, 0, 0);
                DateTime dtnbf = dt0.AddSeconds(nbf);
                if (dtnbf > DateTime.UtcNow.AddHours(-1))
                {
                    return Ok(new { token = authorization });
                }
                long utcnow = Convert.ToInt64((DateTime.UtcNow - dt0).TotalSeconds);
                tk.Payload["exp"] = Convert.ToInt64((DateTime.UtcNow.AddDays(1) - dt0).TotalSeconds);
                var token = tokenHandler.WriteToken(tk);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
