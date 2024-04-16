using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.WebApi.Models;

namespace Library.WebApi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CalificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Califications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calification>>> GetCalifications()
        {
            return await _context.Califications.ToListAsync();
        }

        // GET: api/Califications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calification>> GetCalification(int id)
        {
            var calification = await _context.Califications.FindAsync(id);

            if (calification == null)
            {
                return NotFound();
            }

            return calification;
        }

        // PUT: api/Califications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalification(int id, Calification calification)
        {
            if (id != calification.Id)
            {
                return BadRequest();
            }

            _context.Entry(calification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificationExists(id))
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

        // POST: api/Califications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calification>> PostCalification(Calification calification)
        {
            _context.Califications.Add(calification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalification", new { id = calification.Id }, calification);
        }

        // DELETE: api/Califications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalification(int id)
        {
            var calification = await _context.Califications.FindAsync(id);
            if (calification == null)
            {
                return NotFound();
            }

            _context.Califications.Remove(calification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificationExists(int id)
        {
            return _context.Califications.Any(e => e.Id == id);
        }
    }
}
