using Trinisol.Models;
using Trinisol.Repositories;

namespace Trinisol.Services
{
    public class PresentacionService : IPresentacionService
    {
        private readonly IPresentacionRepository _presentacionRepository;

        public PresentacionService(IPresentacionRepository presentacionRepository)
        {
            _presentacionRepository = presentacionRepository;
        }

        public async Task<IEnumerable<Presentacion>> GetAll()
        {
            return await _presentacionRepository.GetAllWithProductoAsync();
        }

        public async Task<Presentacion?> GetById(int id)
        {
            return await _presentacionRepository.GetByIdWithProductoAsync(id);
        }

        public async Task<IEnumerable<Presentacion>> GetByProducto(int productoId)
        {
            // Buscamos por relación de Producto
            return await _presentacionRepository.FindAsync(p => p.ProductoId == productoId);
        }

        public async Task Add(Presentacion presentacion)
        {
            await _presentacionRepository.AddAsync(presentacion);
        }

        public async Task Create(Presentacion presentacion)
        {
            // Normalmente Create = Add, pero depende de tu diseño
            await _presentacionRepository.AddAsync(presentacion);
        }

        public async Task Update(Presentacion presentacion)
        {
            await _presentacionRepository.UpdateAsync(presentacion);
        }

        public async Task Delete(int id)
        {
            await _presentacionRepository.DeleteAsync(id);
        }
    }
}
