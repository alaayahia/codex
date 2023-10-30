using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCompensation> EmployeeCompensations { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          

            builder.Entity<Employee>()
                  .HasMany(s => s.EmployeeCompensations)      
                  .WithOne(s => s.Employee)
                  .HasForeignKey(s => s.EmpId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Employee>()
                  .HasMany(s => s.EmployeeDocuments)
                  .WithOne(s => s.Employee)
                  .HasForeignKey(s => s.EmpId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Compensation>()
                   .HasMany(s => s.EmployeeCompensations)      
                   .WithOne(s => s.Compensation)
                   .HasForeignKey(s => s.CompId)
                   .OnDelete(DeleteBehavior.NoAction);
                   
        }
        
    }
}