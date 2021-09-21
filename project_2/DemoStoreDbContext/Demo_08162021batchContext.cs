using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project1.ModelsLayer.EfModels;

#nullable disable

namespace Project1.StoreApplication.Storage.Models
{
    public partial class Demo_08162021batchContext : DbContext
    {
        public Demo_08162021batchContext()
        {
        }

        public Demo_08162021batchContext(DbContextOptions<Demo_08162021batchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ItemizedOrder> ItemizedOrders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoresProduct> StoresProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Demo_08162021batch3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordH).HasMaxLength(40);
            });

            modelBuilder.Entity<ItemizedOrder>(entity =>
            {
                entity.HasKey(e => e.ItemizedId)
                    .HasName("PK__Itemized__AB3A49C5F1E40C98");

                entity.Property(e => e.ItemizedId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ItemizedOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ItemizedO__Custo__2E1BDC42");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ItemizedOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemizedO__Produ__300424B4");

                entity.HasOne(d => d.StoreProduct)
                    .WithMany(p => p.ItemizedOrders)
                    .HasForeignKey(d => d.StoreProductId)
                    .HasConstraintName("FK__ItemizedO__Store__2F10007B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPicture)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StoresProduct>(entity =>
            {
                entity.HasKey(e => e.StoreProductId)
                    .HasName("PK__StoresPr__629CD7481D3C9F87");

                entity.ToTable("StoresProduct");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoresProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__StoresPro__Produ__2A4B4B5E");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoresProducts)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoresPro__Store__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
