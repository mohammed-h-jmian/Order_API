using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.API.Data
{
    public class OrderDbContext : IdentityDbContext<User>
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderItem>().HasKey(x => new { x.OrderId , x.MealId});
          //  builder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDelete);
            builder.Entity<User>().HasQueryFilter(x => !x.IsDelete);
        }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order.Data.Models.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
