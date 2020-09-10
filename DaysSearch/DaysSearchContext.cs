using Microsoft.EntityFrameworkCore;

namespace DaysSearch
{
    public class DaysSearchContext : DbContext
    {
        public DaysSearchContext(DbContextOptions options) : base(options) { }

        public DaysSearchContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }

        public DbSet<WeekDays> WeekDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekDays>().HasKey(p => p.Id);
        }
    }
}
