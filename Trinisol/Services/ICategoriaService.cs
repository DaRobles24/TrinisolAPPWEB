using Trinisol.Models;

namespace Trinisol.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task Create(Categoria categoria);
        Task Update(Categoria categoria);
        Task Delete(int id);
    }
}
