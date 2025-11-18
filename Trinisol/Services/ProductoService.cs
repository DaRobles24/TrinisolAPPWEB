using Trinisol.Models;
using Trinisol.Repositories;

namespace Trinisol.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Producto>> GetByCategoria(int categoriaId)
        {
            return await _productoRepository.FindAsync(p => p.CategoriaId == categoriaId);
        }

        public async Task Add(Producto producto)
        {
            await _productoRepository.AddAsync(producto);
        }

        public async Task Create(Producto producto)
        {
            await _productoRepository.AddAsync(producto);
        }

        public async Task Update(Producto producto)
        {
            await _productoRepository.UpdateAsync(producto);
        }

        public async Task Delete(int id)
        {
            await _productoRepository.DeleteAsync(id);
        }
    }
}
