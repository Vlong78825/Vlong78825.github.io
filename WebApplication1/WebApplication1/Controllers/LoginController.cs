using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Interfaces;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserRepository _repository;

        public LoginController(IConfiguration config, IUserRepository repository)
        {
            _configuration = config;
            _repository = repository;
        }
        [HttpPost]
        public ActionResult Post(User data)
        {
            if (data == null || data.username == null || data.password == null)
            {
                return BadRequest();
            }
            var user = _repository.GetUser(data.username, data.password);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }          
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.username)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signIn

            );
            return Ok(new {token= new JwtSecurityTokenHandler().WriteToken(token) });
        }
        [HttpPost("Add")]
        public ActionResult AddUser(User user)
        {   
            if (user.username == null || user.password == null) { return BadRequest("nhap tai khoan,mat khau"); }
            if (_repository.UserExit(user.username)) { return BadRequest("da ton tai"); }
            var any = _repository.CreateUser(user);
            return Ok("Thanh Cong");
        }

    }
}




        