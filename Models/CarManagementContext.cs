using Microsoft.EntityFrameworkCore;

namespace CarManagement.Models
{
    public class CarManagementContext : DbContext
    {
        public CarManagementContext(DbContextOptions<CarManagementContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehiculeType> VehiculeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<VehiculeType>().ToTable("VehiculeType");
        }
    }
}