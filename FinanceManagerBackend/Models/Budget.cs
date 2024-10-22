using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Budget

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Budget (max. 30 characters)

        [MaxLength(200)]
        public string Description { get; set; }  // Description of the Budget (optional, max. 200 characters)

        [Required]
        public int UserId { get; set; }  // ID of the associated User (Required)

        public User User { get; set; }  // Navigation Property for the User

        public decimal StartingCapital { get; set; } = 0;  // Starting capital for the Budget

        [MaxLength(30)]
        public string PaymentMethod { get; set; }  // Payment method for the Budget (max. 30 characters)

        [MaxLength(3)]
        public string Currency { get; set; } = null!;  // Currency of the Budget (e.g., EUR, USD)
    }
}
