using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace LinQExample.Models
{
    public partial class ShopOnline_ShoesContext : DbContext
    {
        public ShopOnline_ShoesContext()
        {
        }

        public ShopOnline_ShoesContext(DbContextOptions<ShopOnline_ShoesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<FavoriteProduct> FavoriteProducts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ReviewDetail> ReviewDetails { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HUYNGUYENGIA;Database=ShopOnline_Shoes;User ID=sa;Password=sa123;Trusted_Connection=False;");
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
            });

            modelBuilder.Entity<FavoriteProduct>(entity =>
            {
                entity.ToTable("FavoriteProduct");

                entity.HasIndex(e => e.IdCustomer, "IX_FavoriteProduct_IdCustomer");

                entity.HasIndex(e => e.IdProductDetail, "IX_FavoriteProduct_IdProductDetail");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.FavoriteProducts)
                    .HasForeignKey(d => d.IdCustomer);

                entity.HasOne(d => d.IdProductDetailNavigation)
                    .WithMany(p => p.FavoriteProducts)
                    .HasForeignKey(d => d.IdProductDetail);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.IdCustomer, "IX_Order_IdCustomer");

                entity.HasIndex(e => e.IdShipper, "IX_Order_IdShipper");

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustomer);

                entity.HasOne(d => d.IdShipperNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdShipper);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdProduct });

                entity.ToTable("OrderDetail");

                entity.HasIndex(e => e.IdProduct, "IX_OrderDetail_IdProduct");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdOrder);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdProduct);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.IdProductDetail, "IX_Product_IdProductDetail");

                entity.HasOne(d => d.IdProductDetailNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdProductDetail);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetail");

                entity.HasIndex(e => e.IdProductType, "IX_ProductDetail_IdProductType");

                entity.HasOne(d => d.IdProductTypeNavigation)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.IdProductType);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.HasIndex(e => e.IdBrand, "IX_ProductType_IdBrand");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.IdBrand);
            });

            modelBuilder.Entity<ReviewDetail>(entity =>
            {
                entity.ToTable("ReviewDetail");

                entity.HasIndex(e => e.IdCustomer, "IX_ReviewDetail_IdCustomer");

                entity.HasIndex(e => e.IdProductDetail, "IX_ReviewDetail_IdProductDetail");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.ReviewDetails)
                    .HasForeignKey(d => d.IdCustomer);

                entity.HasOne(d => d.IdProductDetailNavigation)
                    .WithMany(p => p.ReviewDetails)
                    .HasForeignKey(d => d.IdProductDetail);
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
