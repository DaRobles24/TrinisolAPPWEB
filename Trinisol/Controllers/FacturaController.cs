using Microsoft.AspNetCore.Mvc;
using Trinisol.Data;
using Trinisol.Models.ViewModels;
using Trinisol.Models.Dto;

namespace Trinisol.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Factura/Generar
        public IActionResult Generar()
        {
            var model = new FacturaViewModel
            {
                NumeroFactura = 1100,
                Fecha = DateTime.Now
            };

            // Load DTO lists
            model.Clientes = _context.Clientes
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                })
                .ToList();

            model.Productos = _context.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                })
                .ToList();

            model.Presentaciones = _context.Presentaciones
                .Select(p => new PresentacionDto
                {
                    Id = p.Id,
                    ProductoId = p.ProductoId,
                    NombrePresentacion = p.NombrePresentacion,
                    PrecioUnitario = p.PrecioUnitario
                })
                .ToList();

            return View("Generar", model);  // Views/Factura/Generar.cshtml
        }

        // POST: /Factura/Preview
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Preview(FacturaViewModel model)
        {
            // Validate items
            model.Items = model.Items
                .Where(i => i.ProductoId > 0 && i.Cantidad > 0)
                .ToList();

            // Reload lists (POST loses them)
            model.Clientes = _context.Clientes
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                })
                .ToList();

            model.Productos = _context.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                })
                .ToList();

            model.Presentaciones = _context.Presentaciones
                .Select(p => new PresentacionDto
                {
                    Id = p.Id,
                    ProductoId = p.ProductoId,
                    NombrePresentacion = p.NombrePresentacion,
                    PrecioUnitario = p.PrecioUnitario
                })
                .ToList();

            ViewBag.Cliente = _context.Clientes.First(c => c.Id == model.ClienteId);

            return View("Preview", model);  // Views/Factura/Preview.cshtml
        }
    }
}
