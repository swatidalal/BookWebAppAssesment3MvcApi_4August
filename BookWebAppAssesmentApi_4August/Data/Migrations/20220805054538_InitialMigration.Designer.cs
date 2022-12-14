// <auto-generated />
using System;
using BookWebAppAssesmentApi_4August.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookWebAppAssesmentApi_4August.Data.Migrations
{
    [DbContext(typeof(BookApiDbContext))]
    [Migration("20220805054538_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookWebAppAssesmentApi_4August.Model.Books", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("Zoner")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("BookName")
                        .IsUnique();

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
