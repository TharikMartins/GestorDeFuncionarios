using Microsoft.EntityFrameworkCore;

namespace Management.Infraestructure.DTO
{
    public class EnterpriseContext : DbContext
    {
        public EnterpriseContext(DbContextOptions<EnterpriseContext> options) : base(options)
        {
        }

        public DbSet<EmployeeDTO> EmployeesDTO { get; set; }
        public DbSet<DependentDTO> DependentsDTO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDTO>()
         .HasMany(c => c.Dependents)
         .WithOne(e => e.Employee)
         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
