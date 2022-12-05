﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.Property<Guid>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("Estado");

                    b.HasKey("CarritoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carrito", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarritoProducto", b =>
                {
                    b.Property<Guid>("CarritoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoId");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.HasKey("CarritoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("CarritoProducto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Apellido");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("DNI");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("Telefono");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Apellido = "Gabriele",
                            DNI = "42783553",
                            Direccion = "Calle 28",
                            Nombre = "Candela",
                            Telefono = "1157855587"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Orden", b =>
                {
                    b.Property<Guid>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarritoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CarritoId");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<decimal>("Total")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Total");

                    b.HasKey("OrdenId");

                    b.HasIndex("CarritoId")
                        .IsUnique();

                    b.ToTable("Orden", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Image");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Marca");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<decimal>("Precio")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Precio");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto", (string)null);

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Codigo = "00000001",
                            Descripcion = "10ma generacion",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/39007_1.jpeg",
                            Marca = "Intel",
                            Nombre = "CPU Core i3",
                            Precio = 16000m
                        },
                        new
                        {
                            ProductoId = 2,
                            Codigo = "00000002",
                            Descripcion = "24'' Full HD 60Hz 4Ms",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/33741_1.jpeg",
                            Marca = "Samsung",
                            Nombre = "Monitor Gamer",
                            Precio = 50000m
                        },
                        new
                        {
                            ProductoId = 3,
                            Codigo = "00000003",
                            Descripcion = "Inalambrico gris",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/33306_1.jpeg",
                            Marca = "Logitech",
                            Nombre = "Teclado y Mouse",
                            Precio = 3500m
                        },
                        new
                        {
                            ProductoId = 4,
                            Codigo = "00000004",
                            Descripcion = "4K Rightlight 3",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/35036_2.jpeg",
                            Marca = "Logitech",
                            Nombre = "Camara Web",
                            Precio = 39000m
                        },
                        new
                        {
                            ProductoId = 5,
                            Codigo = "00000005",
                            Descripcion = "2 TB gris",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/disco-portatil_39991_1.jpeg",
                            Marca = "Hikvision",
                            Nombre = "Disco duro externo",
                            Precio = 11000m
                        },
                        new
                        {
                            ProductoId = 6,
                            Codigo = "00000006",
                            Descripcion = "A10 Ps4 gris y azul",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/auricular-gamer_40531_1.jpeg",
                            Marca = "Astro",
                            Nombre = "Auriculares Gamer",
                            Precio = 9000m
                        },
                        new
                        {
                            ProductoId = 7,
                            Codigo = "00000007",
                            Descripcion = "Continua multifuncion",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/impresora-epson-continua_40707_6.jpeg?v906",
                            Marca = "Epson",
                            Nombre = "Impresora L3210",
                            Precio = 67000m
                        },
                        new
                        {
                            ProductoId = 8,
                            Codigo = "00000008",
                            Descripcion = "SSD 480 Gb",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/disco-solido-ssd_34642_4.jpeg",
                            Marca = "Kingston",
                            Nombre = "Disco solido",
                            Precio = 10000m
                        },
                        new
                        {
                            ProductoId = 9,
                            Codigo = "00000009",
                            Descripcion = "5600G 4.4 Ghz - AM4",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40368_1.jpeg",
                            Marca = "Amd",
                            Nombre = "Microprocesador Ryzen 5",
                            Precio = 37000m
                        },
                        new
                        {
                            ProductoId = 10,
                            Codigo = "00000010",
                            Descripcion = "750W",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/38112_3.jpeg?v853",
                            Marca = "Essenses",
                            Nombre = "Fuente de poder",
                            Precio = 5500m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Carritos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.CarritoProducto", b =>
                {
                    b.HasOne("Domain.Entities.Carrito", "Carrito")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Producto", "Producto")
                        .WithMany("CarritoProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Domain.Entities.Orden", b =>
                {
                    b.HasOne("Domain.Entities.Carrito", "Carrito")
                        .WithOne("Orden")
                        .HasForeignKey("Domain.Entities.Orden", "CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("Domain.Entities.Carrito", b =>
                {
                    b.Navigation("CarritoProductos");

                    b.Navigation("Orden")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Carritos");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("CarritoProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
