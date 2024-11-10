using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class ResetPasswordInquiry
    {
        [Key]
        public Guid Guid { get; set; } = Guid.NewGuid();  // Unique identifier for the password reset inquiry (default value is a new GUID)

        public int AccountId { get; set; }  // ID of the associated Account

        [JsonIgnore]
        public Account Account { get; set; }  // Navigation property linking to the Account (not serialized in JSON)

        public DateTime RequestPasswordAttempt { get; set; } = DateTime.Now;  // Timestamp of the password reset request (default is current time)

        [MaxLength(10)]
        public string Code { get; set; }  // Code for password reset (max. 10 characters)
    }

}
