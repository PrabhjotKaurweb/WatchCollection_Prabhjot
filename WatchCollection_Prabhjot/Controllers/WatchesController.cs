using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchCollection_Prabhjot.Data;
using WatchCollection_Prabhjot.Models;

namespace WatchCollection_Prabhjot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Watches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
        {
            return await _context.Watches.ToListAsync();
        }

        // GET: api/Watches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Watch>> GetWatch(int id)
        {
            var watch = await _context.Watches.FindAsync(id);

            if (watch == null)
            {
                return NotFound();
            }

            return watch;
        }

        // PUT: api/Watches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatch(int id, Watch watch)
        {
            if (id != watch.ID)
            {
                return BadRequest();
            }

            _context.Entry(watch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(id))
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

        // POST: api/Watches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Watch>> PostWatch(Watch watch)
        {
            _context.Watches.Add(watch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatch", new { id = watch.ID }, watch);
        }

        // DELETE: api/Watches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Watch>> DeleteWatch(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }

            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return watch;
        }

        private bool WatchExists(int id)
        {
            return _context.Watches.Any(e => e.ID == id);
        }
    }
}
