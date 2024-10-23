using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Expense

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Expense (max. 30 characters)

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;  // Description of the Expense (optional, max. 250 characters)

        public decimal Amount { get; set; } = 0;  // Amount of the Expense

        public int CategoryId { get; set; }  // ID of the associated Category

        public ExpenseIncomeCategory Category { get; set; }  // Category of the Expense (Navigation Property)

        public DateTime Date { get; set; }  // Date of the Expense

        public int? RecurringIncomeExpenseId { get; set; }  // Optional: FK to RecurringIncomeExpense

        public RecurringIncomeExpense RecurringIncomeExpense { get; set; }  // Navigation Property for RecurringIncomeExpense

        public int BudgetId { get; set; }  // ID of the associated Budget

        public Budget Budget { get; set; }  // Budget of the Expense (Navigation Property)
    }
}
