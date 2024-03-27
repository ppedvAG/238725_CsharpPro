using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEfCore.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HalloEfCore;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(x => x.Name)
                                             .IsRequired()
                                             .HasColumnName("DepName")
                                             .HasMaxLength(300);

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
    }
}
