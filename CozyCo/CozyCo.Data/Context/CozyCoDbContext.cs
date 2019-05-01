using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CozyCo.Domain;
using CozyCo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CozyCo.Data.Context
{
    //This class will translate Models into Database tables
    public class CozyCoDbContext : DbContext
    {
        //Per Model as table - add as dbset
        public DbSet<Property> Properties { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  string server = @"Server=(localdb)\mssqllocaldb;Database=cozyco";

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=cozyco;Trusted_Connection=true;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }


}
