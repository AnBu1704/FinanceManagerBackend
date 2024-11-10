using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class LoginLockingDTO
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();  // Unique identifier for the login attempt DTO (default value is a new GUID)

        public int AccountId { get; set; }  // ID of the associated Account

        public DateTime LoginAttempt { get; set; } = DateTime.Now;  // Timestamp of the login attempt (default is current time)
    }

}
