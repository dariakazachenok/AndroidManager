using AndroidManager.Web.Models;
using AndroidManager.WebApi;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AndroidManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly OperatorService operatorService;
        private readonly JwtConfigurationModel jwtConfig;
        private readonly IMapper mapper;

        public AuthController(OperatorService operatorService, JwtConfigurationModel jwtConfig, IMapper mapper)
        {
            this.operatorService = operatorService;
            this.jwtConfig = jwtConfig;
            this.mapper = mapper;
        }

        [HttpPost("token")]
        public ActionResult Signin([FromBody] LoginBindModel model)
        {
            var oper = operatorService.GetByCredentials(model.Email, model.Password);

            if (oper == null) return NotFound();

            var tokenString = BuildToken(oper);

            return Ok(new { Token = tokenString, oper.FirstName });
        }

        private string BuildToken(Operator currentOperator)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtConfig.Issuer,
                jwtConfig.Audience,
                null,
                expires: DateTime.UtcNow.AddMinutes(jwtConfig.ExpireTime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] OperatorBindModel model)
        {
            var oper = mapper.Map<Operator>(model);
            operatorService.Create(oper);
            return Ok();
        }
    }
}
