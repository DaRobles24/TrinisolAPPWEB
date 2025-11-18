using Microsoft.EntityFrameworkCore;
using Trinisol.Data;
using Trinisol.Models;

namespace Trinisol.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Factura>> GetAll()
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ProductosFacturados)
                .ThenInclude(pf => pf.Producto)
                .ToListAsync();
        }

        public async Task<Factura?> GetById(int id)
        {
            return await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ProductosFacturados)
                .ThenInclude(pf => pf.Producto)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Create(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
    }
}
