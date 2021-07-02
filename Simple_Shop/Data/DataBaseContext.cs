using Microsoft.EntityFrameworkCore;
using Simple_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data
{
    public class DataBaseContext  :DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PicPath> PicPaths { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().HasOne(p=>p.PicPath).WithOne(u=>u.Product).HasForeignKey<Product>("PicPath_Id");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("Money");
            modelBuilder.Entity<Product>().Property(p => p.DiscountPrice).HasColumnType("Money");


            modelBuilder.Entity<CategoryToProduct>().HasKey(c => new { c.CategoryId, c.ProductId });

            #region Seed Data

            #region Category


            modelBuilder.Entity<Category>().HasData(

               new Category()
               {
                   Id = 1,
                   Name = "کالاهای دیجیتال",
                   Description = "کالاهای دیجیتال "


               },


               new Category()
               {
                   Id = 2,
                   Name = "لباس و پوشاک",
                   Description = "لباس و پوشاک "


               },
               new Category()
               {
                   Id = 3,
                   Name = "لوازم خانگی",
                   Description = "لوازم خانگی"


               },
               new Category()
               {
                   Id = 4,
                   Name = "لوازم بچه",
                   Description = "لوازم بچه"


               },
               new Category()
               {
                   Id = 5,
                   Name = "لوازم ماشین",
                   Description = "لوازم ماشین"


               }

               );




            #endregion

                #endregion

           base.OnModelCreating(modelBuilder);
        }
    }
}
