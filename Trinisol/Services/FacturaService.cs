using Microsoft.EntityFrameworkCore;
using Trinisol.Data;
using Trinisol.Models;

namespace Trinisol.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ApplicationDbContext _context;

        public FacturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las facturas
        public async Task<List<Factura>> ObtenerFacturasAsync()
        {
            return await _context.Facturas  // <- plural
                .Include(f => f.Cliente)
                .Include(f => f.ProductosFacturados)
                    .ThenInclude(pf => pf.Producto) // opcional, si querés los detalles del producto
                .ToListAsync();
        }

        // Obtener factura por Id
        public async Task<Factura?> ObtenerFacturaPorIdAsync(int id)
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ProductosFacturados)
                    .ThenInclude(pf => pf.Producto) // opcional
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        // Generar una nueva factura
        public async Task<bool> GenerarFacturaAsync(Factura factura)
        {
            try
            {
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
