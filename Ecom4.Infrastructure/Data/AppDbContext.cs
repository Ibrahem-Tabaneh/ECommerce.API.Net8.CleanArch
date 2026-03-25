using Ecom4.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category {Id= Guid.NewGuid(), Name= "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = Guid.NewGuid(), Name = "Clothing", Description = "Apparel and fashion items" },
                new Category { Id = Guid.NewGuid(), Name = "Books", Description = "Books and literature" }
            );
           
        }


    }
}
