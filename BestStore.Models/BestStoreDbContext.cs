using System;
using System.Data;
using BestStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BestStore.Models
{

    public class BestStoreDbContext : IdentityDbContext<IdentityUser>
    {
        //EF Core 2.0
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 在SQLLocalDb 上创建实例
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database =BestStoreDB;Trusted_Connection=True;ConnectRetryCount=0");

            // 在SQLServer 上创建实例
            //optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;User ID=neo;Password=900106;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;uid=neo;pwd=900106;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=EFCoreDB;User Id=neo;Password=900106;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建实例
            builder.Entity<Brand>().HasKey(b => b.BrandID);
            builder.Entity<Category>().HasKey(c => c.CategoryID);
            builder.Entity<OrderDetail>().HasKey(o => o.OrderDetailID);
            builder.Entity<Order>().HasKey(o => o.OrderID);
            builder.Entity<Product>().HasKey(p => p.ProductID);
            builder.Entity<ShipAddress>().HasKey(s => s.AddressID);
            builder.Entity<CartItem>().HasKey(c => c.CartID);
            builder.Entity<WebappUser>().HasKey(u => u.Id);
            builder.Entity<ProductImage>().HasKey(i => i.ImageID);
            base.OnModelCreating(builder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ShipAddress> ShipAddress { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
    }

}