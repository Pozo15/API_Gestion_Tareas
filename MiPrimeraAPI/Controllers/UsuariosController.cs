using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly AppDbContext _context;


        public UsuariosController(AppDbContext context) 
        {
            _context = context;
        }



        // GET: api/usuarios
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);  // ← Retorna 200 OK con los datos
        }

        // GET: api/usuarios/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuarioId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();  // ← Retorna 404 Not Found

            return Ok(usuario);
        }

        // POST: api/usuarios
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Usuario>> InsertarUsuarios(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerUsuarios), new { id = usuario.Id }, usuario);
        }

        // PUT: api/usuarios/1
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuarioId(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usuarios/1
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }






    }
}
