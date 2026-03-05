using Microsoft.AspNetCore.Mvc;
using MvcCubosCarrito.Models;
using MvcCubosCarrito.Repositories.CubosRepo;
using MvcCubosCarrito.Services.CarritoServ;
using MvcCubosCarrito.Services.CuboServ;
using System.Threading.Tasks;

namespace MvcCubosCarrito.Controllers
{
    public class CuboController : Controller
    {
        

        private ICuboService _cuboService;
        private ICarritoService _carritoService;
        ICuboRepository repo;

        public CuboController(ICuboService cuboService, ICarritoService carritoService
            , ICuboRepository repo)
        {
            this._cuboService = cuboService;
            this._carritoService = carritoService;
            this.repo = repo;
        }


        public async Task<IActionResult> Index()
        {

            List<Cubo> model = await this._cuboService.GetCubosAsync();

            return View(model);
        }

        public async Task<IActionResult> AddCarrito(int id)
        {
            this._carritoService.AddCubo(id);

            return RedirectToAction("Index");
        }
    }
}
