using Microsoft.EntityFrameworkCore;
using SomeCompany.Domain.Entities;

namespace SomeCompany.DatabaseProvider
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options)
            : base(options)
        { }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        // todo move building in different types
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDepartmentEntities(modelBuilder);
            ConfigureEmployeeEntity(modelBuilder);
        }

        private static void ConfigureEmployeeEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Employee__A9D105341F912355")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired();

                entity.Property(e => e.Hired)
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DepartmentId)
                    .IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__3B75D760");
            });
        }

        private static void ConfigureDepartmentEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentName)
                    .HasName("UQ__Departme__D949CC34B61AE648")
                    .IsUnique();

                entity.Property(e => e.DepartmentName)
                    .IsRequired();
            });
        }
    }
}
