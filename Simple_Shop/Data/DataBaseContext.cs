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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOne(p=>p.PicPath).WithOne(u=>u.Product).HasForeignKey<Product>("PicPath_Id");
        }
    }
}
