using Microsoft.EntityFrameworkCore;

namespace AndroidManager.Web
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Android> Androids { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
              : base(options)
        {
        }
    }
}
