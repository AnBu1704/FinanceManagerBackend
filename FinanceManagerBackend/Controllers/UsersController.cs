using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceManagerBackend.Data;
using FinanceManagerBackend.Models;
using FinanceManagerBackend.DTOs;

namespace FinanceManagerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                if (_context.Accounts == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                return await _context.Users.ToListAsync(); // Return all accounts
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                if (_context.Users == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                var user = await _context.Users.FindAsync(id); // Find account by ID

                if (user == null)
                {
                    return NotFound(); // Return 404 if account not found
                }

                return user; // Return found account
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserDTO userDTO)
        {
            try
            {
                User user = new User()
                {
                    Id = userDTO.Id,
                    Name = userDTO.Name,
                    Description = userDTO.Description,
                    Color = userDTO.Color,
                    UserPassword = userDTO.UserPassword,
                    AccountId = userDTO.AccountId,
                };

                _context.Users.Add(user); // Add new account
                await _context.SaveChangesAsync(); // Save changes to the database

                return CreatedAtAction("GetUser", new { id = user.Id }, user); // Return 201 with location header
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }

                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (_context.Users == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                var user = await _context.Users.FindAsync(id); // Find user by ID
                if (user == null)
                {
                    return NotFound(); // Return 404 if account not found
                }

                _context.Users.Remove(user); // Remove account
                await _context.SaveChangesAsync(); // Save changes to the database

                return NoContent(); // Return 204 on success
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
