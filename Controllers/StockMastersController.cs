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
    public class StockMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public StockMastersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/StockMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMaster>>> GetStock()
        {
            return await _context.Stock.ToListAsync();
        }

        // GET: api/StockMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMaster>> GetStockMaster(int id)
        {
            var stockMaster = await _context.Stock.FindAsync(id);

            if (stockMaster == null)
            {
                return NotFound();
            }

            return stockMaster;
        }

        // PUT: api/StockMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMaster(int id, StockMaster stockMaster)
        {
            if (id != stockMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockMasterExists(id))
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

        // POST: api/StockMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockMaster>> PostStockMaster(StockMaster stockMaster)
        {
            _context.Stock.Add(stockMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockMaster", new { id = stockMaster.Id }, stockMaster);
        }

        // DELETE: api/StockMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockMaster(int id)
        {
            var stockMaster = await _context.Stock.FindAsync(id);
            if (stockMaster == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stockMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockMasterExists(int id)
        {
            return _context.Stock.Any(e => e.Id == id);
        }
    }
}
