using Gmlu.Demo.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Gmlu.Demo.EntityFramework.DataContext
{
    public class StatsContext : DbContext
    {
        public StatsContext(
            DbContextOptions<StatsContext> options)
        : base(options)
        {
        }

        public DbSet<MeasurePoint> MeasurePoints { get; set; }
        public DbSet<Raspberry> Raspberrys { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurePoint>().ToTable("MeasurePoint");
            modelBuilder.Entity<Raspberry>().ToTable("Raspberry");
        }
    }
}
