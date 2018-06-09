using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuscleFellow.Models.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuscleFellow.Models
{
    public class MuscleFellowDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// 生产商表
        /// </summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// 分类表
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 订单表
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 订单明细表
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 购物车表
        /// </summary>
        public DbSet<CartItem> CartItems { get; set; }

        /// <summary>
        /// 装运地址表
        /// </summary>
        public DbSet<ShipAddress> ShipAddress { get; set; }

        /// <summary>
        /// 商品图片表
        /// </summary>
        public DbSet<ProductImage> ProductImages { get; set; }

        /// <summary>
        /// 省份表
        /// </summary>
        public DbSet<Province> Provinces { get; set; }

        /// <summary>
        /// 城市表
        /// </summary>
        public DbSet<City> Cities { get; set; }
        
        public MuscleFellowDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //创建模型
            builder.Entity<Brand>().HasKey(b => b.BrandID);
            builder.Entity<Category>().HasKey(c => c.CategoryID);
            builder.Entity<OrderDetail>().HasKey(o => o.OrderDetailID);
            builder.Entity<Order>().HasKey(o => o.OrderID);
            builder.Entity<Product>().HasKey(p => p.ProductID);
            builder.Entity<ShipAddress>().HasKey(a => a.AddressID);
            builder.Entity<CartItem>().HasKey(c => c.CartID);
            builder.Entity<ApplicationUser>().HasKey(u => u.Id);
            builder.Entity<ProductImage>().HasKey(p => p.ImageID);

            base.OnModelCreating(builder);
        }

    }
}
