using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PharmacyManagment.Models;

namespace PharmacyManagment.Data;

public partial class PharmcyContext : DbContext
{
    public PharmcyContext()
    {
    }

    public PharmcyContext(DbContextOptions<PharmcyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=pharmcy;integrated security=true;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.City).IsFixedLength();
            entity.Property(e => e.CustomerName).IsFixedLength();
            entity.Property(e => e.Email).IsFixedLength();
            entity.Property(e => e.Phone).IsFixedLength();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK_Employees_Employees1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order Details_Orders");

            entity.HasOne(d => d.Product).WithMany().HasConstraintName("FK_Order Details_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categorys");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
