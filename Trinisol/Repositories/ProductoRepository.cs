using System.Linq.Expressions;
using Trinisol.Data;
using Trinisol.Models;
using Microsoft.EntityFrameworkCore;

namespace Trinisol.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los productos con categoría y presentaciones
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Presentaciones)
                .AsNoTracking()
                .ToListAsync();
        }

        // Obtener un producto por Id
        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Presentaciones)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Buscar productos según un filtro
        public async Task<IEnumerable<Producto>> FindAsync(Expression<Func<Producto, bool>> predicate)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Presentaciones)
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        // Agregar un producto
        public async Task AddAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        // Actualizar un producto
        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        // Eliminar un producto por Id
        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
