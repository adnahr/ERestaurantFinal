using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restoran.DTO;
using Restoran.models;
namespace Restoran.Controllers
{
    [EnableCors("RestaurantPolicy")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RestoranDBContext _context;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            RestoranDBContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpPost("api/login")]
        public async Task<ActionResult> Login([FromBody] SignInDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);
                return Ok(new { title = await GenerateJwtToken(model.Username, appUser) });
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost("api/register")]
        public async Task<IActionResult> Register([FromBody] SignUpDTO model)
        {
            var RUnit = _context.restaurantUnits.Where(r => r.UnitId == model.RestaurantUnit).Single();
         // var RUnit = _context.restaurantUnits.Single(r => r.UnitId == model.RestaurantUnit);
            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                UserName = model.Username,
                Email = model.Email,
                HireDate = model.HireDate,
                RestaurantUnit = RUnit
                
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(new { token = await GenerateJwtToken(model.Username, user) });
            }

            var errors = result.Errors;
            var message = string.Join(" ,", errors);


            return NotFound(message);
        }

        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}