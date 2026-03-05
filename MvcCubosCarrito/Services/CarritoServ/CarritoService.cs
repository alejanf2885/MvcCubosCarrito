
using Microsoft.Extensions.Caching.Memory;
using MvcCubosCarrito.Models;
using MvcCubosCarrito.Repositories.CubosRepo;
using MvcCubosCarrito.Services.CuboServ;

namespace MvcCubosCarrito.Services.CarritoServ
{
    public class CarritoService : ICarritoService
    {

        private IMemoryCache _memoryCache;
        private ICuboService _cuboService;
        private ICuboRepository _cuboRepository;


        public CarritoService(IMemoryCache memoryCache, ICuboService cuboService, ICuboRepository cuboRepository)
        {
            this._memoryCache = memoryCache;
            this._cuboService = cuboService;
            this._cuboRepository = cuboRepository;
        }

        public async Task<bool> AddCubo(int id)
        {

            Cubo cubo = await this._cuboRepository.GetCuboAsync(id);

            Carrito carrito = this._memoryCache.Get<Carrito>("CARRITO");

            if (carrito == null)
            {
                carrito = new Carrito();


                CuboCarrito cuboCarrito = new CuboCarrito();
                List<CuboCarrito> cubos = new List<CuboCarrito>();

                cuboCarrito.Id = cubo.Id;
                cuboCarrito.Cantidad = cuboCarrito.Cantidad + 1;
                cuboCarrito.Precio = cuboCarrito.Cantidad * cuboCarrito.Precio;

                carrito.cubos = cubos;
                carrito.cubos.Add(cuboCarrito);

                this._memoryCache.Set<Carrito>("CARRITO", carrito);

                return true;

            }
            else
            {
                //Tiene comprobamos si existe el cubo


                CuboCarrito cuboCarrito = carrito.cubos.Find(z => z.Id == id);

                if (cuboCarrito != null)
                {
                    carrito.cubos.Remove(cuboCarrito);
                    cuboCarrito.Cantidad = cuboCarrito.Cantidad + 1;
                    cuboCarrito.Precio = cuboCarrito.Cantidad * cuboCarrito.Precio;

                    carrito.cubos.Add(cuboCarrito);

                    this._memoryCache.Set<Carrito>("CARRITO", carrito);

                    return true;

                }
                else
                {
                    cuboCarrito = new CuboCarrito();



                    cuboCarrito.Id = cubo.Id;
                    cuboCarrito.Cantidad = cuboCarrito.Cantidad + 1;
                    cuboCarrito.Precio = cuboCarrito.Cantidad * cuboCarrito.Precio;

                    carrito.cubos.Add(cuboCarrito);

                    this._memoryCache.Set<Carrito>("CARRITO", carrito);

                    return true;

                }



            }


        }

        public Task<bool> DeleteCubo(int id)
        {
            throw new NotImplementedException();
        }



        public Carrito GetCarrito()
        {
            Carrito carrito = this._memoryCache.Get<Carrito>("CARRITO"); 
            return carrito;
        }
    }
}
