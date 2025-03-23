using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingSystem.Models;
using System.Data;


namespace BillingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMastersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserMastersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/UserMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMaster>>> GetUserMasters(string role)
        {
            if (_context.UserMasters == null)
            {
                return NotFound();
            }

            IQueryable<UserMaster> usersQuery = _context.UserMasters;

            if (!string.IsNullOrEmpty(role))
            {
                usersQuery = usersQuery.Where(u => u.Role.RoleName == role);
            }

            var users = await usersQuery.ToListAsync();
            return users;
        }

        // GET: api/UserMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMaster>> GetUserMaster(int id, string role)
        {
            if (_context.UserMasters == null)
            {
                return NotFound();
            }

            var userMaster = await _context.UserMasters
                .Where(u => u.Id == id && u.Role.RoleName == role)
                .FirstOrDefaultAsync();

            if (userMaster == null)
            {
                return NotFound();
            }

            return userMaster;
        }

        // PUT: api/UserMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMaster(int id, UserMaster userMaster)
        {
            if (id != userMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(userMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMasterExists(id))
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


        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] UserMaster userObj)
        {
            if (userObj == null) { return BadRequest(); }

            var user = await _context.UserMasters.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);
            if (user == null) { return NotFound(new { Message = "User Not Found!" }); }

            return Ok(new
            {
                Message = "Login Success!"
            });
        }
        // POST: api/UserMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMaster>> PostUserMaster(UserMaster userMaster)
        {

            if (_context.UserMasters == null)
            {
                return Problem("Entity set 'AppDbContext.Usermaster'  is null.");
            }
            // Check if the role exists
            var role = await _context.RoleMasters.FindAsync(userMaster.RoleId);
            if (role == null)
            {
                return BadRequest("Invalid role specified.");
            }
            //check if the email is alreay registered
            var existinguser = await _context.UserMasters.FirstOrDefaultAsync(x => x.Email == userMaster.Email);
            if (existinguser != null)
            {
                return BadRequest("Email is already registered");
            }
            RoleMaster r = _context.RoleMasters.SingleOrDefault(e => e.RoleId.Equals(userMaster.RoleId));
            // create a new user or supplier based on the role
            if (r.RoleName.Equals("user"))
            {
                var newUser = new UserMaster
                {
                    Email = userMaster.Email,
                    FullName = userMaster.FullName,
                    Password = userMaster.Password,
                    Address = userMaster.Address,
                    ContactNo = userMaster.ContactNo,
                    RoleId = role.RoleId,
                    ActiveFlag = true

                };
                _context.UserMasters.Add(userMaster);
            }
            else if (r.RoleName.Equals("supplier"))
            {
                var newSupplier = new UserMaster
                {
                    Email = userMaster.Email,
                    FullName = userMaster.FullName,
                    Password = userMaster.Password,
                    Address = userMaster.Address,
                    ContactNo = userMaster.ContactNo,
                    CompanyName = userMaster.CompanyName,
                    RoleId = role.RoleId,

                    ActiveFlag = true
                };
                _context.UserMasters.Add(newSupplier);
            }
            else
            {
                return BadRequest("Invalid role specified.");
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Registration successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");


                // return CreatedAtAction("GetUserMaster", new { id = userMaster.Id }, userMaster);
            }
        }



        // DELETE: api/UserMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMaster(int id)
        {
            var userMaster = await _context.UserMasters.FindAsync(id);
            if (userMaster == null)
            {
                return NotFound();
            }

            _context.UserMasters.Remove(userMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMasterExists(int id)
        {
            return _context.UserMasters.Any(e => e.Id == id);
        }
    }
}
