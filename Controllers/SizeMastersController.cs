using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Models;

namespace BillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SizeMastersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/SizeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeMaster>>> GetsizeMasters()
        {
            return await _context.sizeMasters.ToListAsync();
        }

        // GET: api/SizeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeMaster>> GetSizeMaster(int id)
        {
            var sizeMaster = await _context.sizeMasters.FindAsync(id);

            if (sizeMaster == null)
            {
                return NotFound();
            }

            return sizeMaster;
        }

        // PUT: api/SizeMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeMaster(int id, SizeMaster sizeMaster)
        {
            if (id != sizeMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(sizeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeMasterExists(id))
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

        // POST: api/SizeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeMaster>> PostSizeMaster(SizeMaster sizeMaster)
        {
            _context.sizeMasters.Add(sizeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeMaster", new { id = sizeMaster.Id }, sizeMaster);
        }

        // DELETE: api/SizeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeMaster(int id)
        {
            var sizeMaster = await _context.sizeMasters.FindAsync(id);
            if (sizeMaster == null)
            {
                return NotFound();
            }

            _context.sizeMasters.Remove(sizeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeMasterExists(int id)
        {
            return _context.sizeMasters.Any(e => e.Id == id);
        }
    }
}
