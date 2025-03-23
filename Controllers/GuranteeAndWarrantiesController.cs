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
    public class GuranteeAndWarrantiesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public GuranteeAndWarrantiesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/GuranteeAndWarranties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuranteeAndWarranty>>> Getguranty()
        {
            return await _context.guranty.ToListAsync();
        }

        // GET: api/GuranteeAndWarranties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuranteeAndWarranty>> GetGuranteeAndWarranty(int id)
        {
            var guranteeAndWarranty = await _context.guranty.FindAsync(id);

            if (guranteeAndWarranty == null)
            {
                return NotFound();
            }

            return guranteeAndWarranty;
        }

        // PUT: api/GuranteeAndWarranties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuranteeAndWarranty(int id, GuranteeAndWarranty guranteeAndWarranty)
        {
            if (id != guranteeAndWarranty.Id)
            {
                return BadRequest();
            }

            _context.Entry(guranteeAndWarranty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuranteeAndWarrantyExists(id))
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

        // POST: api/GuranteeAndWarranties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuranteeAndWarranty>> PostGuranteeAndWarranty(GuranteeAndWarranty guranteeAndWarranty)
        {
            _context.guranty.Add(guranteeAndWarranty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuranteeAndWarranty", new { id = guranteeAndWarranty.Id }, guranteeAndWarranty);
        }

        // DELETE: api/GuranteeAndWarranties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuranteeAndWarranty(int id)
        {
            var guranteeAndWarranty = await _context.guranty.FindAsync(id);
            if (guranteeAndWarranty == null)
            {
                return NotFound();
            }

            _context.guranty.Remove(guranteeAndWarranty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuranteeAndWarrantyExists(int id)
        {
            return _context.guranty.Any(e => e.Id == id);
        }
    }
}
