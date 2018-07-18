using AndroidManager.Web.Models;
using AndroidManager.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly JwtConfigurationModel _jwtConfig;

        public AuthController(UserService userService, JwtConfigurationModel jwtConfig)
        {
            _userService = userService;
            _jwtConfig = jwtConfig;
        }

        [HttpPost("token")]
        public ActionResult Signin([FromBody] OperatorBindModel model)
        {
            var user = _userService.GetByCredentials(model.Email, model.Password);

            if (user == null) return NotFound();

            var tokenString = BuildToken(user);

            return Ok(new { Token = tokenString, user.FirstName });
        }

        private string BuildToken(Operator currentOperator)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtConfig.Issuer,
                _jwtConfig.Audience,
                null,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfig.ExpireTime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

