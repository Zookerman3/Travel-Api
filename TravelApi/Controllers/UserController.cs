using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace TravelApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly TravelApiContext _db;
        private readonly JwtSettings jwtSettings;

        public UserController(TravelApiContext db, IOptions<JwtSettings> options)
        {
            _db = db;
            jwtSettings = options.Value;
        }


        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenicate([FromBody] UserCred userCred)
        {
            var user = await _db.Users.FirstOrDefaultAsync(item => item.UserId == userCred.username && item.Password == userCred.password);

            if (user == null)
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(jwtSettings.securitykey);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.Name, user.UserId) }),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDesc);
            string finalToken = tokenHandler.WriteToken(token);


            return Ok(finalToken);
        }
    }
}