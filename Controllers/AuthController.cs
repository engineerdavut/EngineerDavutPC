using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using RannaPanelManagement.Business.Abstract;

namespace RannaPanelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly ICustomerService _customerService;
        private readonly string _jwtKey = "8cZ#xJHU!E&6&6zpD!Jh4J%5XIR!o8";

        public AuthController(IManagerService managerService, ICustomerService customerService)
        {
            _managerService = managerService;
            _customerService = customerService;
        }

        [HttpPost("manager-login")]
        public IActionResult ManagerLogin(string userName, string password)
        {
            var manager = _managerService.GetByUsernameAndPassword(userName, password);
            if (manager == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(manager.Id, manager.UserName, "manager");
            return Ok(new { token = token });
        }

        [HttpPost("customer-login")]
        public IActionResult CustomerLogin(string customerName, string password)
        {
            var customer = _customerService.GetByUsernameAndPassword(customerName, password);
            if (customer == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(customer.Id, customer.UserName, "customer");
            return Ok(new { token = token });
        }

        private string GenerateToken(int id, string userName, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", id.ToString()),
                new Claim("role", role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
