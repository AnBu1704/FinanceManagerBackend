using Microsoft.EntityFrameworkCore;



namespace FinanceManagerBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
