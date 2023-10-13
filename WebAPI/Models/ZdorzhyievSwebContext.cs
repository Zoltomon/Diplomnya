using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class ZdorzhyievSwebContext : DbContext
{
    public ZdorzhyievSwebContext()
    {
    }

    public ZdorzhyievSwebContext(DbContextOptions<ZdorzhyievSwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonalDatum> PersonalData { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleItem> SaleItems { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=VH293.spaceweb.ru;port=3308;user=zdorzhyiev_sweb;database=zdorzhyiev_sweb;password=QBLQKt4BNMU7H&2A", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<PersonalDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("персональная информация о юзерах"));

            entity.HasIndex(e => e.UserProfileId, "UserId");

            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.NumberPassport).HasMaxLength(6);
            entity.Property(e => e.Patronomic).HasMaxLength(40);
            entity.Property(e => e.SeriesPassport).HasMaxLength(4);
            entity.Property(e => e.Surname).HasMaxLength(40);

            entity.HasOne(d => d.UserProfile).WithMany(p => p.PersonalData)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("PersonalData_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Product", tb => tb.HasComment("информация о товарах"));

            entity.HasIndex(e => e.ProductCategoryId, "ProductCategoryId");

            entity.HasIndex(e => e.SupplierId, "SupplierId");

            entity.Property(e => e.Article).HasMaxLength(50);
            entity.Property(e => e.Barcode).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("Product_ibfk_1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("Product_ibfk_2");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ProductCategory", tb => tb.HasComment("информация о категории товаров"));

            entity.Property(e => e.NameCategory).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role", tb => tb.HasComment("информация о ролях"));

            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable(tb => tb.HasComment("информация о продажах"));
        });

        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("SaleItem", tb => tb.HasComment("информация о продажах(товар, окончательная цена и кол-во)"));

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.HasIndex(e => e.SalesId, "SalesId");

            entity.HasIndex(e => e.UserProfileId, "UserProfileId");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("SaleItem_ibfk_2");

            entity.HasOne(d => d.Sales).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.SalesId)
                .HasConstraintName("SaleItem_ibfk_1");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.UserProfileId)
                .HasConstraintName("SaleItem_ibfk_3");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Status", tb => tb.HasComment("информация о статусах"));

            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Supplier", tb => tb.HasComment("информация о поставщиках"));

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Itn)
                .HasMaxLength(12)
                .HasColumnName("ITN");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Telephone).HasMaxLength(13);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("UserProfile", tb => tb.HasComment("данные о юзерах"));

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.StatusId, "StatusId");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(40);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Telephone).HasMaxLength(13);

            entity.HasOne(d => d.Role).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("UserProfile_ibfk_2");

            entity.HasOne(d => d.Status).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("UserProfile_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
