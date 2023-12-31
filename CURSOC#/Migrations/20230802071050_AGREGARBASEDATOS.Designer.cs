﻿// <auto-generated />
using CURSOC_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CURSOC_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230802071050_AGREGARBASEDATOS")]
    partial class AGREGARBASEDATOS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CURSOC_.Models.ProvinciaC", b =>
                {
                    b.Property<int>("conprovincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("conprovincia"));

                    b.Property<string>("nomprovincia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("conprovincia");

                    b.ToTable("Provincias");
                });
#pragma warning restore 612, 618
        }
    }
}
