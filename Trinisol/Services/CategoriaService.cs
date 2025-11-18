using Trinisol.Models;
using Trinisol.Repositories;

namespace Trinisol.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaService(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Categoria>> GetAll() =>
            await _repo.GetAllAsync();

        public async Task<Categoria?> GetById(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task Create(Categoria categoria) =>
            await _repo.AddAsync(categoria);

        public async Task Update(Categoria categoria) =>
            await _repo.UpdateAsync(categoria);

        public async Task Delete(int id) =>
            await _repo.DeleteAsync(id);
    }
}
