using Microsoft.AspNetCore.Mvc;
using MvcCubosCarrito.Models;
using MvcCubosCarrito.Services.CarritoServ;
using System.Threading.Tasks;

namespace MvcCubosCarrito.Controllers
{
    public class CarritoController : Controller
    {
        private ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            this._carritoService = carritoService;
        }
        public async Task<IActionResult> Index()
        {
            Carrito carrito = this._carritoService.GetCarrito();
            ViewData["Total"] = carrito.cubos.Sum(z => z.PrecioTotal);

            return View(carrito);
        }

        
        public async Task<IActionResult> DeleteCuboCarrito(int id)
        {
            await this._carritoService.DeleteCuboAsync(id);

            return RedirectToAction("Index");
        }
    }
}
