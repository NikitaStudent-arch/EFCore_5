using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EFCore_5.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base()
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Coment> Coments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=COMP1M;Database=Shop_P51;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Устанавливаем отношение "многие ко многим" между заказами и продуктами
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany() // Якщо у класі Product немає навігаційної властивості Orders, залиште WithMany() порожнім
                .UsingEntity<Dictionary<string, object>>(
                    "OrderProducts",
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId")
                );

            // Устанавливаем связь "один ко многим" между заказами и клиентами
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany() // Якщо у класі Client є колекція Orders, вкажіть c => c.Orders
                .HasForeignKey(o => o.ClientId)
                .IsRequired(); // Замінює HasRequired з EF6

        }

    }
}
