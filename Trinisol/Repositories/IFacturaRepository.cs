using Trinisol.Models;

namespace Trinisol.Repositories
{
    public interface IFacturaRepository
    {
        Task<List<Factura>> GetAll();
        Task<Factura?> GetById(int id);
        Task Create(Factura factura);
    }
}
