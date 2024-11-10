using Microsoft.EntityFrameworkCore;

using FinanceManagerBackend.Models;

namespace FinanceManagerBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Budget> Budget { get; set; }
        
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseIncomeCategory> ExpenseIncomeCategorys { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<LoginLocking> LoginLockings { get; set; }

        public DbSet<RecurringIncomeExpense> RecurringIncomeExpenses { get; set; }

        public DbSet<ResetPasswordInquiry> ResetPasswordInquiries { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecurringIncomeExpense>()
                .HasMany(r => r.Incomes)
                .WithOne(i => i.RecurringIncomeExpense)
                .HasForeignKey(i => i.RecurringIncomeExpenseId);  // FK für Income

            modelBuilder.Entity<RecurringIncomeExpense>()
                .HasMany(r => r.Expenses)
                .WithOne(e => e.RecurringIncomeExpense)
                .HasForeignKey(e => e.RecurringIncomeExpenseId);  // FK für Expense
        }
    }

    

}
