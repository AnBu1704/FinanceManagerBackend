using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceManagerBackend.Data;
using FinanceManagerBackend.Models;
using FinanceManagerBackend.DTOs;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using FinanceManagerBackend.Services;
using FinanceManagerBackend;

namespace FinanceManagerBackend.Controllers
{
    public class LoginRequestData
    {
        public string Mail { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class ForgotPasswordResponse
    {
        public int Status { get; set; }

        public string Message { get; set; } = null!;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly EmailService _emailService;

        public AccountsController(DataContext context, EmailService emailService)
        {
            _context = context; // Initialize DataContext
            _emailService = emailService; // Initialize EmailService
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
                                        Salt = a.Salt,
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
                    Salt = accountDto.Salt,
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

        // POST: api/Accounts/Login
        [HttpPost("Login")]
        public async Task<ActionResult<AccountInfoDTO>> Login(LoginRequestData data)
        {
            try
            {
                // Ensure the context is not null (check for existing accounts and users)
                if (_context.Accounts == null || _context.Users == null)
                {
                    return NotFound(); // Return 404 if no accounts or users are found
                }

                // Retrieve account login information by matching the provided email
                var accountLoginInfo = await _context.Accounts
                    .Where(a => a.EMail == data.Mail)
                    .Select(a => new
                    {
                        Id = a.Id,
                        EMail = a.EMail,
                        Password = a.Password,
                        Salt = a.Salt,
                    })
                    .FirstOrDefaultAsync();

                // Check if the account exists
                if (accountLoginInfo == null)
                {
                    return NoContent(); // Return 204 if no account matches the given email
                }
                else
                {
                    DateTime fiveMinutesAgo = DateTime.UtcNow.AddMinutes(-5);
                    //Check login attempts
                    var loginAttempts = _context.LoginLockings.Count(ll => ll.AccountId == accountLoginInfo.Id &&
                                                                            ll.LoginAttempt >= fiveMinutesAgo);

                    if (loginAttempts <= 3)
                    {
                        // Extract stored salt and hash from the database
                        string storedSalt = accountLoginInfo.Salt;
                        string storedHash = accountLoginInfo.Password;

                        // Hash the input password with the stored salt
                        string inputHash = HashPassword(data.Password, storedSalt);

                        // Validate if the generated hash matches the stored hash
                        if (inputHash == storedHash)
                        {
                            var accountInfo = GetAccountInfo(accountLoginInfo.Id).Result.Value;

                            if (accountInfo != null)
                            {
                                return accountInfo; // Return account information if login is successful
                            }
                            else
                            {
                                return Problem("ERROR: Error while loading AccountInfo"); // Log and return a detailed error if account data is missing
                            }
                        }
                        else
                        {
                            // Create a new login locking row with a unique GUID
                            Guid guid = Guid.NewGuid();

                            LoginLocking loginLocking = new LoginLocking()
                            {
                                Guid = guid,
                                AccountId = accountLoginInfo.Id,
                                LoginAttempt = DateTime.Now
                            };

                            // Add the LoginLockings to the database and save changes
                            _context.LoginLockings.Add(loginLocking);
                            await _context.SaveChangesAsync();

                            return Unauthorized("Invalid credentials"); // Return 401 for incorrect credentials
                        }
                    }
                    else
                    {
                        return BadRequest("Entered incorrect login information too often");
                    }
                }
            }
            catch (Exception ex)
            {
                // Return detailed error information for debugging
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        // andrebutze.mail@googlemail.com
        // GET: api/Accounts/Forgot-Password/{email}
        [HttpGet("Forgot-Password/{email}")]
        public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword(string email)
        {
            try
            {
                // Ensure the context is not null (check for existing accounts)
                if (_context.Accounts == null)
                {
                    return NotFound(); // Return 404 if no accounts are found
                }
                else if (!AccountExists(email))
                {
                    return NotFound(); // Return 404 if no account with the given email exists
                }
                else
                {
                    // Generate a random 10-digit code for password reset
                    string code = "";
                    for (int x = 0; x < 10; x++)
                    {
                        code += new Random().Next(10).ToString();
                    }

                    // Prepare the email content with the reset code
                    var subject = "Password Reset";
                    var body = new MailTemplates().htmlForgotPassword1 + $"{code}" + new MailTemplates().htmlForgotPassword2;

                    // Send the reset email
                    await _emailService.SendEmailAsync(email, subject, body);

                    // Create a new password reset inquiry with a unique GUID
                    Guid guid = Guid.NewGuid();
                    int accountId = _context.Accounts.Where(a => a.EMail == email)
                                                     .Select(a => a.Id).FirstOrDefault();

                    ResetPasswordInquiry inquiry = new ResetPasswordInquiry()
                    {
                        Guid = guid,
                        AccountId = accountId,
                        RequestPasswordAttempt = DateTime.Now,
                        Code = code,
                    };

                    // Add the inquiry to the database and save changes
                    _context.ResetPasswordInquiries.Add(inquiry);
                    await _context.SaveChangesAsync();

                    // Verify the inquiry has been saved
                    var rpw = _context.ResetPasswordInquiries.Where(r => r.Guid == guid)
                                                             .Select(r => new { }).FirstOrDefault();

                    if (rpw == null)
                    {
                        return Problem("ERROR: No row in ResetPasswordInquiries"); // Log if inquiry was not found post-save
                    }

                    return new ForgotPasswordResponse()
                    {
                        Message = "Reset email has been sent.",
                        Status = 200
                    };
                }
            }
            catch (Exception ex)
            {
                // Return detailed error information for debugging
                return Problem("ERROR: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static string GenerateSalt()
        {
            // Create a byte array to hold the salt (16 bytes long)
            byte[] salt = new byte[16];

            // Use RNGCryptoServiceProvider to fill the array with a cryptographically strong sequence of random values
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Fill the byte array with random bytes
            }

            // Convert the byte array to a Base64 string and return it (used for easy storage and comparison)
            return Convert.ToBase64String(salt);
        }


        public static string HashPassword(string password, string salt)
        {
            // Create an instance of SHA256 to compute the hash
            using (var sha256 = SHA256.Create())
            {
                // Concatenate the password with the salt to create a salted input
                var saltedPassword = password + salt;

                // Convert the salted input to a byte array and compute the hash
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert the resulting hash byte array to a Base64 string and return it
                return Convert.ToBase64String(hashBytes);
            }
        }


        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id); // Check if account exists by ID
        }

        private bool AccountExists(string email)
        {
            return _context.Accounts.Any(e => e.EMail == email); // Check if account exists by ID
        }

    }
}
