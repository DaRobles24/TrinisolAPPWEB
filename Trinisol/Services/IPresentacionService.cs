using Trinisol.Models;

namespace Trinisol.Services
{
    public interface IPresentacionService
    {
        Task<IEnumerable<Presentacion>> GetAll();
        Task<Presentacion?> GetById(int id);
        Task<IEnumerable<Presentacion>> GetByProducto(int productoId);
        Task Add(Presentacion presentacion);
        Task Create(Presentacion presentacion);
        Task Update(Presentacion presentacion);
        Task Delete(int id);
    }
}
