using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace otopark.DataAccess.Concrete.EntityFramework.Context
{
    public class OtoparkDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASUS;Database=otoparkDb;Trusted_Connection=true");
        }

       // public DbSet<Product> Products { get; set; }

     
    }
}
