using System.Collections.Generic;
using System.Threading.Tasks;
using Trinisol.Models;
using Trinisol.Repositories;

namespace Trinisol.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task CreateAsync(Cliente cliente)
        {
            await _repo.CreateAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await _repo.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
