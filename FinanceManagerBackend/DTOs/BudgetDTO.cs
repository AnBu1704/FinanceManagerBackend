using FinanceManagerBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.DTOs
{
    public class BudgetDTO
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Budget

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Budget (max. 30 characters)

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;  // Description of the Budget (optional, max. 200 characters)

        public decimal StartingCapital { get; set; } = 0;  // Starting capital for the Budget

        [MaxLength(30)]
        public string PaymentMethod { get; set; }  // Payment method for the Budget (max. 30 characters)

        [MaxLength(3)]
        public string Currency { get; set; } = null!;  // Currency of the Budget (e.g., EUR, USD)
    }
}
