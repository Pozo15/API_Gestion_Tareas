using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using MiPrimeraAPI.Services;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
         
        private readonly IConfiguration _configuration;

        private readonly JwtService _jwtService;

        public AuthController (
            AppDbContext context, IConfiguration configuration,
            JwtService jwtService)
        {
            _context = context;
            _configuration = configuration;
            _jwtService = jwtService;   
        }

        


        [HttpPost("Register")]

        public async Task<IActionResult>Register(Usuario request)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == request.Email))
                return BadRequest("El correo ya existe");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);


            var user = new Usuario
            {
                Email = request.Email,
                PasswordHash = passwordHash

            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Correo registrado correctamente");

        }


        [HttpPost("Login")]

        public async Task<IActionResult>Login(LoginModel request)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash))
                          return Unauthorized("Correo o contraseña invalidos");


            string token = _jwtService.GenerateToken(user);
            return Ok(new { token });
            
        }



    }
}
