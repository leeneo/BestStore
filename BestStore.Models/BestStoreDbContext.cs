using System;
using System.Data;
using BestStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BestStore.Data
{

    public class BestStoreDbContext : IdentityDbContext<IdentityUser>
    {
        //EF Core 2.0
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 在SQLLocalDb 上创建实例
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database =BestStoreDB;Trusted_Connection=True;ConnectRetryCount=0");

            // 在MSSQLServe 上创建实例
            //optionsBuilder.UseSqlServer(@"Server=.\mssql;Initial Catalog=EFCore;uid=neo;pwd=900106;ConnectRetryCount=0");

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