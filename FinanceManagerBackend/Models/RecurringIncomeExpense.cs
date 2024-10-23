using System.ComponentModel.DataAnnotations;

namespace FinanceManagerBackend.Models
{
    public class RecurringIncomeExpense
    {
        [Key]
        public int Id { get; set; }  // Unique identifier for the Recurring Income/Expense

        public bool IsExpense { get; set; } = true;  // Indicates if the entry is an Expense (true) or Income (false)

        [MaxLength(30)]
        public string Name { get; set; } = null!;  // Name of the Recurring Income/Expense (max. 30 characters)

        public decimal Amount { get; set; } = 0; // Amount for the Recurring Income/Expense

        public DateTime StartDate { get; set; }  // Start date of the Recurring Income/Expense

        public int RecurringPeriod { get; set; }  // Frequency of the recurrence (e.g., days, weeks, months)

        public bool IsActive { get; set; }  // Indicates if the Recurring Income/Expense is currently active

        public List<Income> Incomes { get; set; } = new List<Income>();  // Related Income records

        public List<Expense> Expenses { get; set; } = new List<Expense>();  // Related Expense records
    }

}
