using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/categorias
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> ObtenerTodas()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return Ok(categorias);
        }

        // GET: api/categorias/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> ObtenerPorId(int id)
        {
            var categoria = await _context.Categorias
                .Include(c => c.Tareas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        // POST: api/categorias
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Categoria>> Crear(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = categoria.Id }, categoria);
        }

        // PUT: api/categorias/1
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest();

            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/categorias/1
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound();

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
