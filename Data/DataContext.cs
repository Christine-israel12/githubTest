using Exceltodb_expenseentry.EFModels;
using Microsoft.EntityFrameworkCore;


namespace Exceltodb_expenseentry.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ExpenseEntry> expense_entry { get; set; }



    }
}
