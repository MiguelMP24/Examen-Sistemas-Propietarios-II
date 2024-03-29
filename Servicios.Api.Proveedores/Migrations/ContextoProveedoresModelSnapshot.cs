﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servicios.Api.Proveedores.Persistence;

#nullable disable

namespace Servicios.Api.Proveedores.Migrations
{
    [DbContext(typeof(ContextoProveedores))]
    partial class ContextoProveedoresModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Servicios.Api.Proveedores.Models.ModeloProveedores", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dirección")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProveedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProveedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SitioWeb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ModeloProveedores");
                });
#pragma warning restore 612, 618
        }
    }
}
