using Trinisol.Models;

namespace Trinisol.Services
{
    public interface IFacturaService
    {
        Task<List<Factura>> ObtenerFacturasAsync();
        Task<Factura?> ObtenerFacturaPorIdAsync(int id);
        Task<bool> GenerarFacturaAsync(Factura factura);
    }
}
