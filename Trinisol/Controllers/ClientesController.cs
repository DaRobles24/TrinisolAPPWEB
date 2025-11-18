using Microsoft.AspNetCore.Mvc;
using Trinisol.Models;
using Trinisol.Services;

namespace Trinisol.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _service.GetAllAsync();
            return View(clientes);
        }

        public IActionResult Create()
        {
            ViewBag.Provincias = new List<string>
    {
        "San José",
        "Alajuela",
        "Cartago",
        "Heredia",
        "Guanacaste",
        "Puntarenas",
        "Limón"
    };

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _service.CreateAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            ViewBag.Provincias = new List<string>
    {
        "San José",
        "Alajuela",
        "Cartago",
        "Heredia",
        "Guanacaste",
        "Puntarenas",
        "Limón"
    };
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _service.UpdateAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
