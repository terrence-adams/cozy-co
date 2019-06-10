using CozyCo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CozyCo.Data.Context
{
    //This class will translate Models into Database tables
    public class CozyCoDbContext : IdentityDbContext<AppUser>
    {
        //Per Model as table - add as dbset
        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Lease> Leases { get; set; }

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


            modelBuilder.Entity<Lease>()
                .HasKey(l => new { l.PropertyId, l.TenantId });

            modelBuilder.Entity<Lease>()
            .HasOne(l => l.Tenant)
            .WithMany(t => t.Leases)
            .HasForeignKey(l => l.TenantId);


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Tenant", NormalizedName = "Tenant" },
                new IdentityRole { Name = "Landlord", NormalizedName = "LANDLORD" }
                );

        }
    }
}