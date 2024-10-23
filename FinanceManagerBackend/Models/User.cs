using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceManagerBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the User

        public int AccountId { get; set; }  // ID of the associated Account

        public Account Account { get; set; }  // Account of the User (Navigation Property)

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the User (max. 30 characters)

        [MaxLength(64)]
        public string UserPassword { get; set; } = string.Empty;  // Password of the User (max. 64 characters)

        public int Color { get; set; }  // Color value for the User (e.g., as a hex code)

        [JsonIgnore]
        public List<Budget>? Budgets { get; set; }  // Associated Budgets of the User (Navigation Property)
    }
}
