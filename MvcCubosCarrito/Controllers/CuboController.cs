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
        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(Cubo cubo)
        {
            bool resultado = await this._cuboService.InsertCuboAsync
                (cubo.Id, cubo.Nombre, cubo.Modelo, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddCarrito(int id)
        {
            await  this._carritoService.AddCuboAsync(id);

            return RedirectToAction("Index");
        }
    }
}
