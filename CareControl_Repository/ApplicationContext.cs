using Microsoft.EntityFrameworkCore;
using System;

namespace CareControl_Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new ProductMap(modelBuilder.Entity<Product>());
            //new ProductDetailMap(modelBuilder.Entity<ProductDetails>());
        }
    }
}
