using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trinisol.Models;
using Trinisol.Services;

namespace Trinisol.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;

        public ProductosController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        // GET: /Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetAll();
            return View(productos);
        }

        // GET: /Productos/Create
        public async Task<IActionResult> Create()
        {
            await CargarCategorias();
            return View();
        }

        // POST: /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                await CargarCategorias();
                return View(producto);
            }

            await _productoService.Create(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.GetById(id);
            if (producto == null)
                return NotFound();

            await CargarCategorias(producto.CategoriaId);
            return View(producto);
        }

        // POST: /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await CargarCategorias(producto.CategoriaId);
                return View(producto);
            }

            await _productoService.Update(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.GetById(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Método privado para cargar categorías en el ViewBag
        private async Task CargarCategorias(int? selectedId = null)
        {
            var categorias = await _categoriaService.GetAll();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", selectedId);
        }
    }
}
