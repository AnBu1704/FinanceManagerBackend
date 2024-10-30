using FinanceManagerBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.DTOs
{
    public class AccountInfoDTO
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Account

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Account (max. 30 characters)

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;  // Description of the Account (optional, max. 200 characters)

        [MaxLength(256)]
        public string EMail { get; set; } = null!;  // Email address of the Account (max. 256 characters)

        [MaxLength(64)]
        public string Password { get; set; } = null!;  // Password of the Account (max. 64 characters)

        public List<UserDTO>? Users { get; set; }  // Associated Users of the Account (Navigation Property)
    }
}
