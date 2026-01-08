using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblSalaryHistory> TblSalaryHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EmployeeManagementDb;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC072CA735F5");

            entity.ToTable("Tbl_Departments");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC072D0AC901");

            entity.ToTable("Tbl_Employees");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");
        });

        modelBuilder.Entity<TblSalaryHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalaryHi__3214EC075859514D");

            entity.ToTable("Tbl_SalaryHistory");

            entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblSalaryHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalaryHistory_Employees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
