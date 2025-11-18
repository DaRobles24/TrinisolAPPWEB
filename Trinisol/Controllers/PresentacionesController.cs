using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trinisol.Models;
using Trinisol.Services;

namespace Trinisol.Controllers
{
    public class PresentacionesController : Controller
    {
        private readonly IPresentacionService _presentacionService;
        private readonly IProductoService _productoService;

        public PresentacionesController(IPresentacionService presentacionService, IProductoService productoService)
        {
            _presentacionService = presentacionService;
            _productoService = productoService;
        }

        public async Task<IActionResult> Index(int? productoId)
        {
            if (productoId != null)
            {
                var lista = await _presentacionService.GetByProducto(productoId.Value);
                return View(lista);
            }

            return View(await _presentacionService.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Productos = new SelectList(await _productoService.GetAll(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = new SelectList(await _productoService.GetAll(), "Id", "Nombre");
                return View(presentacion);
            }

            await _presentacionService.Create(presentacion);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var presentacion = await _presentacionService.GetById(id);

            if (presentacion == null)
                return NotFound();

            ViewBag.Productos = new SelectList(await _productoService.GetAll(), "Id", "Nombre", presentacion.ProductoId);
            return View(presentacion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Presentacion presentacion)
        {
            if (id != presentacion.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Productos = new SelectList(await _productoService.GetAll(), "Id", "Nombre", presentacion.ProductoId);
                return View(presentacion);
            }

            await _presentacionService.Update(presentacion);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var presentacion = await _presentacionService.GetById(id);
            if (presentacion == null)
                return NotFound();

            return View(presentacion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _presentacionService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
