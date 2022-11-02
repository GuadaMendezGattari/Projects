using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Comentarios.Data;
using Microsoft.EntityFrameworkCore;
using Comentarios.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comentarios.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioDbContext _context;

        public ComentarioController(ComentarioDbContext context)
        {
            _context = context;
        }

        // GET: api/comentario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var comentarios = await _context.Comentario.ToListAsync();
                return Ok(comentarios);
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);
                if (comentario == null) return NotFound();
                return Ok(comentario);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return Ok(comentario);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if (id != comentario.Id) return BadRequest();
                _context.Update(comentario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario actualizado con exito" });
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);
                if (comentario == null) return NotFound();
                _context.Comentario.Remove(comentario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario eliminado con exito" });
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

