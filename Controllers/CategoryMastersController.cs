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
    public class CategoryMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CategoryMastersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/CategoryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryMaster>>> GetCategoryMasters()
        {
            return await _context.CategoryMasters.ToListAsync();
        }

        // GET: api/CategoryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryMaster>> GetCategoryMaster(int id)
        {
            var categoryMaster = await _context.CategoryMasters.FindAsync(id);

            if (categoryMaster == null)
            {
                return NotFound();
            }

            return categoryMaster;
        }

        // PUT: api/CategoryMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryMaster(int id, CategoryMaster categoryMaster)
        {
            if (id != categoryMaster.Id)
            {
                return BadRequest(new { message = "Category ID mismatch." });
            }

            // Ensure the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(categoryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryMasterExists(id))
                {
                    return NotFound(new { message = "Category not found." });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while updating the category.", details = ex.Message });
            }

            return NoContent();
        }

        

        private bool CategoryMasterExists(int id)
        {
            return _context.CategoryMasters.Any(e => e.Id == id);
        }

        // POST: api/CategoryMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryMaster>> PostCategoryMaster(CategoryMaster categoryMaster)
        {
            _context.CategoryMasters.Add(categoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryMaster", new { id = categoryMaster.Id }, categoryMaster);
        }

        // DELETE: api/CategoryMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryMaster(int id)
        {
            var categoryMaster = await _context.CategoryMasters.FindAsync(id);
            if (categoryMaster == null)
            {
                return NotFound();
            }

            _context.CategoryMasters.Remove(categoryMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
