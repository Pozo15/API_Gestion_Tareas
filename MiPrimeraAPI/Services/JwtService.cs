using Microsoft.IdentityModel.Tokens;
using MiPrimeraAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiPrimeraAPI.Services
{
    public class JwtService
    {

        private readonly IConfiguration _configuration;

        public JwtService (IConfiguration configuration)
        {
            _configuration = configuration;
        }   


        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.Name,usuario.Email),
              new Claim("UserId",usuario.Id.ToString()),

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken
                (
                   issuer: _configuration["Jwt:Issuer"],
                   audience: _configuration["Jwt:Audience"],
                   claims: claims,
                   expires: DateTime.UtcNow.AddMinutes(15),
                   signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
