using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tinhthanh2Controller : ControllerBase
    {
        private readonly tinhthanh2Context _context;

        public tinhthanh2Controller(tinhthanh2Context context)
        {
            _context = context;
        }

        // GET: api/tinhthanh2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tinhthanh2>>> Gettinhthanh2s()
        {
            return await _context.tinhthanh2s.ToListAsync();
        }

        // GET: api/tinhthanh2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tinhthanh2>> Gettinhthanh2(int id)
        {
            var tinhthanh2 = await _context.tinhthanh2s.FindAsync(id);

            if (tinhthanh2 == null)
            {
                return NotFound();
            }

            return tinhthanh2;
        }

        // PUT: api/tinhthanh2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttinhthanh2(int id, tinhthanh2 tinhthanh2)
        {
            if (id != tinhthanh2.id)
            {
                return BadRequest();
            }

            _context.Entry(tinhthanh2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tinhthanh2Exists(id))
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

        // POST: api/tinhthanh2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tinhthanh2>> Posttinhthanh2(tinhthanh2 tinhthanh2)
        {
            _context.tinhthanh2s.Add(tinhthanh2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettinhthanh2", new { id = tinhthanh2.id }, tinhthanh2);
        }

        // DELETE: api/tinhthanh2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetinhthanh2(int id)
        {
            var tinhthanh2 = await _context.tinhthanh2s.FindAsync(id);
            if (tinhthanh2 == null)
            {
                return NotFound();
            }

            _context.tinhthanh2s.Remove(tinhthanh2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tinhthanh2Exists(int id)
        {
            return _context.tinhthanh2s.Any(e => e.id == id);
        }
    }
}
