using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Data;
using MiPrimeraAPI.Models;
using System.Threading;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TareasController (AppDbContext context)
        {
            _context = context;
        }


        // GET: api/nombre
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> ObtenerTarea()
        {
            var tareas = await _context.Tareas.ToListAsync();
            return Ok(tareas);
        }

        // GET: api/nombre/1
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerTareaPorId(int id)
        {
            var tareas = await _context.Tareas
                .Include(t => t.Categoria)
                .FirstOrDefaultAsync(t => t.Id == id);
            

            if (tareas == null)
            {
                return NotFound();
                
            }

            return Ok(tareas);
        }

        // POST: api/nombre
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Tarea>> CrearTarea(Tarea modelo)
        {
            _context.Tareas.Add(modelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerTareaPorId), new {id = modelo.Id }, modelo);
        }

        // PUT: api/nombre/1
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();  

            return NoContent();

        }

        // DELETE: api/nombre/1
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();

        }



        [Authorize]
        [HttpGet("pendientes")]
        public async Task<ActionResult<IEnumerable<Tarea>>> ObtenerPendientes()
        {
            var tareas = await _context.Tareas
                .Where(t => t.Estado == false)
                .ToListAsync();

            return Ok(tareas);
        }


        [Authorize]
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> ObtenerPorUsuario(int id)
        {
            var misTareas = await _context.Tareas
                .Where(t => t.UsuarioId == id)
                .ToListAsync();

            return Ok(misTareas);
        }


        [Authorize]
        [HttpGet("urgentes")]
        public async Task<ActionResult<IEnumerable<Tarea>>> ObtenerUrgentes()
        {
            var urgentes = await _context.Tareas
                .Where(t => t.Prioridad == "Alta")
                .ToListAsync();

            return Ok(urgentes);
        }







    }
}
