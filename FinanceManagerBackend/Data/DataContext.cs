using Microsoft.EntityFrameworkCore;

using FinanceManagerBackend.Models;

namespace FinanceManagerBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
