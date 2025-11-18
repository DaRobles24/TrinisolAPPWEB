using Microsoft.AspNetCore.Mvc;
using Trinisol.Models;
using Trinisol.Services;

namespace Trinisol.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            var categorias = await _service.GetAll();
            return View(categorias);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            await _service.Create(categoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _service.GetById(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoria);

            await _service.Update(categoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _service.GetById(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
