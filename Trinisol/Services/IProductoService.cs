using Trinisol.Models;

namespace Trinisol.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task<IEnumerable<Producto>> GetByCategoria(int categoriaId);
        Task Add(Producto producto);
        Task Create(Producto producto);
        Task Update(Producto producto);
        Task Delete(int id);
    }
}
