using Microsoft.AspNetCore.Mvc;
using Trinisol.Data;
using Trinisol.Models.ViewModels;
using Trinisol.Models.Dto;
using Trinisol.Models;
using Microsoft.EntityFrameworkCore;

namespace Trinisol.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Factura/Generar - PÁGINA ÚNICA CON TODO
        public IActionResult Generar()
        {
            var model = new FacturaViewModel
            {
                NumeroFactura = 1100,
                Fecha = DateTime.Now
            };

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

            return View("Generar", model);
        }

        // POST: /Factura/Guardar - Guarda directo desde el formulario único
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guardar(FacturaViewModel model)
        {
            try
            {
                // Filtrar solo items válidos
                var itemsValidos = model.Items
                    .Where(i => i.ProductoId > 0 && i.PresentacionId > 0 && i.Cantidad > 0)
                    .ToList();

                if (!itemsValidos.Any())
                {
                    TempData["Error"] = "Debe agregar al menos un producto";
                    return RedirectToAction("Generar");
                }

                // Calcular totales
                decimal subtotalProductos = 0;
                foreach (var item in itemsValidos)
                {
                    var presentacion = await _context.Presentaciones.FindAsync(item.PresentacionId);
                    if (presentacion != null)
                    {
                        subtotalProductos += presentacion.PrecioUnitario * item.Cantidad;
                    }
                }

                var factura = new Factura
                {
                    NumeroFactura = model.NumeroFactura,
                    Fecha = model.Fecha,
                    ClienteId = model.ClienteId,
                    MetodoPago = model.MetodoPago ?? "Sinpe",
                    SaldoPendiente = model.SaldoPendiente,
                    Pago = model.Pago,
                    Total = subtotalProductos + model.SaldoPendiente,
                    FacturadoPor = model.FacturadoPor,
                    TelefonoFacturador = model.TelefonoFacturador,
                    ProductosFacturados = new List<ProductoFactura>()
                };

                foreach (var item in itemsValidos)
                {
                    var presentacion = await _context.Presentaciones.FindAsync(item.PresentacionId);

                    factura.ProductosFacturados.Add(new ProductoFactura
                    {
                        ProductoId = item.ProductoId,
                        PresentacionId = item.PresentacionId,
                        Cantidad = item.Cantidad,
                        PrecioUnitario = presentacion.PrecioUnitario
                    });
                }

                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Factura guardada exitosamente";
                return RedirectToAction("Detalle", new { id = factura.Id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al guardar la factura: " + ex.Message;
                return RedirectToAction("Generar");
            }
        }

        // GET: /Factura/Detalle/5
        public async Task<IActionResult> Detalle(int id)
        {
            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.ProductosFacturados)
                    .ThenInclude(pf => pf.Producto)
                .Include(f => f.ProductosFacturados)
                    .ThenInclude(pf => pf.Presentacion)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (factura == null)
            {
                return NotFound();
            }

            return View("Detalle", factura);
        }

        // GET: /Factura/Lista
        public async Task<IActionResult> Lista()
        {
            var facturas = await _context.Facturas
                .Include(f => f.Cliente)
                .OrderByDescending(f => f.Fecha)
                .ToListAsync();

            return View("Lista", facturas);
        }
    }
}