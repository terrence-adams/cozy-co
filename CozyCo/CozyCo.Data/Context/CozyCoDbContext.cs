using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Domain;
using CozyCo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CozyCo.Data.Context
{
    //This class will translate Models into Database tables
    public class CozyCoDbContext : IdentityDbContext<AppUser>
    {
        //Per Model as table - add as dbset
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  string server = @"Server=(localdb)\mssqllocaldb;Database=cozyco";

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=cozyco;Trusted_Connection=true;";

            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, Description = "Condo" },
                new PropertyType { Id = 2, Description = "Single Family Home" },
                new PropertyType { Id = 3, Description = "Duplex" }
                );
        }
    }


}
