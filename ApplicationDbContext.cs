using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Chocolate> Chocolates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
