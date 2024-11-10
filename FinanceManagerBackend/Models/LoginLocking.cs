using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class LoginLocking
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();  // Unique identifier for the login attempt (default value is a new GUID)

        public int AccountId { get; set; }  // ID of the associated Account

        [JsonIgnore]
        public Account Account { get; set; }  // Navigation property linking to the Account (not serialized in JSON)

        public DateTime LoginAttempt { get; set; } = DateTime.Now;  // Timestamp of the login attempt (default is current time)
    }

}
