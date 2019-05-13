﻿// <auto-generated />
using CozyCo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CozyCo.Data.Migrations
{
    [DbContext(typeof(CozyCoDbContext))]
    [Migration("20190513025845_PropertyType")]
    partial class PropertyType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CozyCo.Domain.Models.Property", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Image");

                    b.Property<int>("PropertyTypeId");

                    b.Property<string>("Zipcode")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("CozyCo.Domain.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Condo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Single Family Home"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Duplex"
                        });
                });

            modelBuilder.Entity("CozyCo.Domain.Models.Property", b =>
                {
                    b.HasOne("CozyCo.Domain.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
