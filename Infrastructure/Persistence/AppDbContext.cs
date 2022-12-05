using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }

     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(c => c.ClienteId);
                entity.Property(c => c.DNI).HasMaxLength(10).HasColumnName("DNI");
                entity.Property(c => c.Nombre).HasMaxLength(25).HasColumnName("Nombre");
                entity.Property(c => c.Apellido).HasMaxLength(25).HasColumnName("Apellido");
                entity.Property(c => c.Direccion).HasColumnName("Direccion");
                entity.Property(c => c.Telefono).HasMaxLength(13).HasColumnName("Telefono");

                entity.HasData(
                    new Cliente
                    {
                        ClienteId = 1,
                        DNI = "42783553",
                        Nombre = "Candela",
                        Apellido = "Gabriele",
                        Direccion = "Calle 28",
                        Telefono = "1157855587"
                    }
                    );
            });


            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");
                entity.HasKey(c => c.CarritoId);
                entity.Property(c => c.ClienteId).HasColumnName("ClienteId");
                entity.Property(c => c.Estado).HasColumnName("Estado");

                entity
                    .HasOne<Cliente>(c => c.Cliente)
                    .WithMany(s => s.Carritos)
                    .HasForeignKey(c => c.ClienteId);

                entity
                    .HasOne<Orden>(c => c.Orden)
                    .WithOne(o => o.Carrito)
                    .HasForeignKey<Orden>(o => o.CarritoId);
            });


            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.ToTable("CarritoProducto");
                entity.HasKey(c => new { c.CarritoId, c.ProductoId });
                entity.Property(c => c.ProductoId).HasColumnName("ProductoId");
                entity.Property(c => c.Cantidad).HasColumnName("Cantidad");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(p => p.ProductoId);
                entity.Property(p => p.Nombre).HasColumnName("Nombre");
                entity.Property(p => p.Descripcion).HasColumnName("Descripcion");
                entity.Property(p => p.Marca).HasColumnName("Marca").HasMaxLength(25);
                entity.Property(p => p.Codigo).HasColumnName("Codigo").HasMaxLength(25);
                entity.Property(p => p.Precio).HasColumnName("Precio").HasPrecision(15, 2);
                entity.Property(p => p.Image).HasColumnName("Image");

                entity.HasData(
                new Producto
                {
                    ProductoId = 1,
                    Nombre = "CPU Core i3",
                    Descripcion = "10ma generacion",
                    Marca = "Intel",
                    Codigo = "00000001",
                    Precio = 16000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/39007_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 2,
                    Nombre = "Monitor Gamer",
                    Descripcion = "24'' Full HD 60Hz 4Ms",
                    Marca = "Samsung",
                    Codigo = "00000002",
                    Precio = 50000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/33741_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 3,
                    Nombre = "Teclado y Mouse",
                    Descripcion = "Inalambrico gris",
                    Marca = "Logitech",
                    Codigo = "00000003",
                    Precio = 3500,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/33306_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 4,
                    Nombre = "Camara Web",
                    Descripcion = "4K Rightlight 3",
                    Marca = "Logitech",
                    Codigo = "00000004",
                    Precio = 39000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/35036_2.jpeg",
                },
                new Producto
                {
                    ProductoId = 5,
                    Nombre = "Disco duro externo",
                    Descripcion = "2 TB gris",
                    Marca = "Hikvision",
                    Codigo = "00000005",
                    Precio = 11000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/disco-portatil_39991_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 6,
                    Nombre = "Auriculares Gamer",
                    Descripcion = "A10 Ps4 gris y azul",
                    Marca = "Astro",
                    Codigo = "00000006",
                    Precio = 9000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/auricular-gamer_40531_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 7,
                    Nombre = "Impresora L3210",
                    Descripcion = "Continua multifuncion",
                    Marca = "Epson",
                    Codigo = "00000007",
                    Precio = 67000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/impresora-epson-continua_40707_6.jpeg?v906"
                },
                new Producto
                {
                    ProductoId = 8,
                    Nombre = "Disco solido",
                    Descripcion = "SSD 480 Gb",
                    Marca = "Kingston",
                    Codigo = "00000008",
                    Precio = 10000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/disco-solido-ssd_34642_4.jpeg",
                },
                new Producto
                {
                    ProductoId = 9,
                    Nombre = "Microprocesador Ryzen 5",
                    Descripcion = "5600G 4.4 Ghz - AM4",
                    Marca = "Amd",
                    Codigo = "00000009",
                    Precio = 37000,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40368_1.jpeg",
                },
                new Producto
                {
                    ProductoId = 10,
                    Nombre = "Fuente de poder",
                    Descripcion = "750W",
                    Marca = "Essenses",
                    Codigo = "00000010",
                    Precio = 5500,
                    Image = "https://mexx-img-2019.s3.amazonaws.com/38112_3.jpeg?v853",
                }
                );
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(o => o.OrdenId);
                entity.Property(o => o.CarritoId).HasColumnName("CarritoId");
                entity.Property(o => o.Fecha).HasColumnName("Fecha");
                entity.Property(o => o.Total).HasColumnName("Total").HasPrecision(15, 2);
            });

        }
    }
}
