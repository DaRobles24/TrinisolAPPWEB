using Microsoft.EntityFrameworkCore;
using Trinisol.Data;
using Trinisol.Models;

namespace Trinisol.Repositories
{
    public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacionRepository
    {
        private readonly ApplicationDbContext _context;

        public PresentacionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Presentacion>> GetAllWithProductoAsync()
        {
            return await _context.Presentaciones
                .Include(p => p.Producto)
                .ToListAsync();
        }

        public async Task<Presentacion?> GetByIdWithProductoAsync(int id)
        {
            return await _context.Presentaciones
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
