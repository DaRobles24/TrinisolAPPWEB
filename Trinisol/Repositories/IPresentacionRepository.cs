using Trinisol.Models;

namespace Trinisol.Repositories
{
    public interface IPresentacionRepository : IGenericRepository<Presentacion>
    {
        Task<IEnumerable<Presentacion>> GetAllWithProductoAsync();
        Task<Presentacion?> GetByIdWithProductoAsync(int id);
    }
}
