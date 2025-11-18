using Microsoft.EntityFrameworkCore;
using Trinisol.Models;

namespace Trinisol.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas principales
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Tablas de facturación
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProductoFactura> ProductosFacturados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Producto - Categoría
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Presentación - Producto
            modelBuilder.Entity<Presentacion>()
                .HasOne(p => p.Producto)
                .WithMany(prod => prod.Presentaciones)
                .HasForeignKey(p => p.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Factura - Cliente
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación ProductoFactura - Factura
            modelBuilder.Entity<ProductoFactura>()
                .HasOne(pf => pf.Factura)
                .WithMany(f => f.ProductosFacturados)
                .HasForeignKey(pf => pf.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación ProductoFactura - Producto
            modelBuilder.Entity<ProductoFactura>()
                .HasOne(pf => pf.Producto)
                .WithMany()
                .HasForeignKey(pf => pf.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
