using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria_API.Models
{
    public partial class _2019SBDContext : DbContext
    {
        public _2019SBDContext()
        {
        }

        public _2019SBDContext(DbContextOptions<_2019SBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscountCodes> DiscountCodes { get; set; }
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<OrderItemsIngridients> OrderItemsIngridients { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<PizzasIngridients> PizzasIngridients { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<SpecialOffers> SpecialOffers { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "s14996");

            modelBuilder.Entity<DiscountCodes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Ingridients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_OrderItems");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_Pizza_OrderItems");
            });

            modelBuilder.Entity<OrderItemsIngridients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngridientId).HasColumnName("Ingridient_ID");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_ID");

                entity.HasOne(d => d.Ingridient)
                    .WithMany(p => p.OrderItemsIngridients)
                    .HasForeignKey(d => d.IngridientId)
                    .HasConstraintName("FK_Ingridient_OrderItems");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.OrderItemsIngridients)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("FK_OrderItem_Ingridients");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiscountCode).HasMaxLength(15);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_ID");

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.HasOne(d => d.DiscountCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountCode)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Codes_Orders");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Orders");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Orders");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PizzasIngridients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngridientId).HasColumnName("Ingridient_ID");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.HasOne(d => d.Ingridient)
                    .WithMany(p => p.PizzasIngridients)
                    .HasForeignKey(d => d.IngridientId)
                    .HasConstraintName("FK_Ingridient_Pizzas");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzasIngridients)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_Ingridients_Pizza");
            });

            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SpecialOffers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.SpecialOffers)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_Pizza_SpecialOffers");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });
        }
    }
}
