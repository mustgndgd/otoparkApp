using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using otopark.Entities.Concrete;

namespace otopark.DataAccess.Concrete.EntityFramework.Context
{
    public class OtoparkDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASUS;Database=otoparkDb;Trusted_Connection=true");
        }

        public DbSet<CarPark> CarParks { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


    }
}
