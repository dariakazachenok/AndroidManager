using Microsoft.EntityFrameworkCore;

namespace AndroidManager.Web
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Android> Androids { get; set; }
        public DbSet<Operator> Operators { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AndroidJob>().HasKey(pc => new { pc.AndroidId, pc.JobId });
        }
    }
}
