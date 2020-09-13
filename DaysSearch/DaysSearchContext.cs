using Microsoft.EntityFrameworkCore;
using System;

namespace DaysSearch
{
    public class DaysSearchContext : DbContext
    {
        public DaysSearchContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("InMemoryProvider");

        public DbSet<WeekDays> WeekDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekDays>().HasKey(p => p.Id);

            modelBuilder.Entity<WeekDays>().HasData(
                new WeekDays { Id = Guid.NewGuid(), Monday = "Sunny", Tuesday = "Cloudless" },
                new WeekDays { Id = Guid.NewGuid(), Wednesday = "Rainy" },
                new WeekDays { Id = Guid.NewGuid(), Thursday = "Rainy", Friday = "Cloudless" }
            );
        }
    }
}
