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
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountsController(DataContext context)
        {
            _context = context; // Initialize DataContext
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            try
            {
                if (_context.Accounts == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                return await _context.Accounts.ToListAsync(); // Return all accounts
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            try
            {
                if (_context.Accounts == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                var account = await _context.Accounts.FindAsync(id); // Find account by ID

                if (account == null)
                {
                    return NotFound(); // Return 404 if account not found
                }

                return account; // Return found account
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // GET: api/Accounts/Info/5
        [HttpGet("Info/{id}", Name = "GetAccountInfo")]
        public async Task<ActionResult<AccountInfoDTO>> GetAccountInfo(int id)
        {
            List<User> users = new List<User>();

            try
            {
                if (_context.Accounts == null ||
                    _context.Users == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                var accountInfo =
                    await _context.Accounts
                                    .Where(a => a.Id == id)
                                    .Select(a => new AccountInfoDTO()
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        Description = a.Description,
                                        EMail = a.EMail,
                                        Password = a.Password,
                                        Users = a.Users.Select(u => new UserDTO()
                                        {
                                            Id = u.Id,
                                            Name = u.Name,
                                            Description = u.Description,
                                            Color = u.Color,
                                        }).ToList(),
                                    }).FirstOrDefaultAsync();

                if (accountInfo != null)
                {
                    return accountInfo; // Return found account 
                }
                else
                {
                    return NotFound(); // Return 404 if account not found
                }
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<Account>> AddAccount(AccountDTO accountDto)
        {
            try
            {
                Account account = new Account()
                {
                    Id = accountDto.Id,
                    Name = accountDto.Name,
                    Description = accountDto.Description,
                    EMail = accountDto.EMail,
                    Password = accountDto.Password,
                };

                _context.Accounts.Add(account); // Add new account
                await _context.SaveChangesAsync(); // Save changes to the database

                return CreatedAtAction("GetAccount", new { id = account.Id }, account); // Return 201 with location header
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAccount(int id, Account account)
        {
            try
            {
                if (id != account.Id)
                {
                    return BadRequest(); // Return 400 if ID mismatch
                }

                _context.Entry(account).State = EntityState.Modified; // Mark entity as modified

                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound(); // Return 404 if account doesn't exist
                }
                else
                {
                    return Problem("ERROR"); // Log concurrency issue
                }
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }

            return NoContent(); // Return 204 on success
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                if (_context.Accounts == null)
                {
                    return NotFound(); // Return 404 if no accounts exist
                }

                var account = await _context.Accounts.FindAsync(id); // Find account by ID
                if (account == null)
                {
                    return NotFound(); // Return 404 if account not found
                }

                _context.Accounts.Remove(account); // Remove account
                await _context.SaveChangesAsync(); // Save changes to the database

                return NoContent(); // Return 204 on success
            }
            catch (Exception ex)
            {
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace); // Log and return error
            }
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id); // Check if account exists by ID
        }

    }
}
