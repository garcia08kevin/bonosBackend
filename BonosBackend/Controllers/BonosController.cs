#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BonosBackend.Data;
using BonosBackend.Models;

namespace BonosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonosController : ControllerBase
    {
        private readonly DataContext _context;

        public BonosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Bonos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bono>>> GetBonos()
        {
            return await _context.Bonos.ToListAsync();
        }

        // GET: api/Bonos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bono>> GetBono(int id)
        {
            var bono = await _context.Bonos.FindAsync(id);

            if (bono == null)
            {
                return NotFound();
            }

            return bono;
        }

        // PUT: api/Bonos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBono(int id, Bono bono)
        {
            if (id != bono.id)
            {
                return BadRequest();
            }

            _context.Entry(bono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bonos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bono>> PostBono(Bono bono)
        {
            _context.Bonos.Add(bono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBono", new { id = bono.id }, bono);
        }

        // DELETE: api/Bonos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBono(int id)
        {
            var bono = await _context.Bonos.FindAsync(id);
            if (bono == null)
            {
                return NotFound();
            }

            _context.Bonos.Remove(bono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BonoExists(int id)
        {
            return _context.Bonos.Any(e => e.id == id);
        }
    }
}
