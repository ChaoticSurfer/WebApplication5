using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChocolatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Chocolates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chocolate>>> GetChocolates()
        {
            return await _context.Chocolates.ToListAsync();
        }

        // GET: api/Chocolates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chocolate>> GetChocolate(int id)
        {
            var chocolate = await _context.Chocolates.FindAsync(id);

            if (chocolate == null)
            {
                return NotFound();
            }

            return chocolate;
        }

        // PUT: api/Chocolates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChocolate(int id, Chocolate chocolate)
        {
            if (id != chocolate.Id)
            {
                return BadRequest();
            }

            _context.Entry(chocolate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChocolateExists(id))
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

        // POST: api/Chocolates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chocolate>> PostChocolate(Chocolate chocolate)
        {
            _context.Chocolates.Add(chocolate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChocolate", new { id = chocolate.Id }, chocolate);
        }

        // DELETE: api/Chocolates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChocolate(int id)
        {
            var chocolate = await _context.Chocolates.FindAsync(id);
            if (chocolate == null)
            {
                return NotFound();
            }

            _context.Chocolates.Remove(chocolate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChocolateExists(int id)
        {
            return _context.Chocolates.Any(e => e.Id == id);
        }
    }
}
