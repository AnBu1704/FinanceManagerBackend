using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.Models
{
    public class ExpenseIncomeCategory
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Category

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Category (max. 30 characters)

        [MaxLength(30)]
        public string Symbol { get; set; }  // Symbol for the Category (optional, max. 30 characters)

        public int Color { get; set; }  // Color value for the Category (e.g., as a hex code)

        public List<Income> Incomes { get; set; }  // Associated Incomes (Navigation Property)

        public List<Expense> Expenses { get; set; }  // Associated Expenses (Navigation Property)
    }
}
