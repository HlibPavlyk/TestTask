using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                     
        }
        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public void ClearTable()
        {
            Database.ExecuteSqlRaw("DELETE FROM ConfigurationItems");
        }
    }
}
