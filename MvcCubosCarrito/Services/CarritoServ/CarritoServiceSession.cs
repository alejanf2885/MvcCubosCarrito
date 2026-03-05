using MvcCubosCarrito.Extensions;
using MvcCubosCarrito.Models;
using MvcCubosCarrito.Repositories.CubosRepo;
using System.Threading.Tasks;

namespace MvcCubosCarrito.Services.CarritoServ
{
    public class CarritoServiceSession : ICarritoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICuboRepository _cuboRepository;

        public CarritoServiceSession(IHttpContextAccessor httpContextAccessor, ICuboRepository cuboRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _cuboRepository = cuboRepository;
        }

        public async Task<bool> AddCuboAsync(int id)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            List<CuboCarritoSimple> carritoIds = session.GetObject<List<CuboCarritoSimple>>("CARRITO") ?? new List<CuboCarritoSimple>();

            CuboCarritoSimple cubo = carritoIds.Find(x => x.Id == id);
            if (cubo != null)
            {
                cubo.Cantidad += 1;
            }
            else
            {
                CuboCarritoSimple cuboNuevo = new CuboCarritoSimple { Id = id, Cantidad = 1 };
                carritoIds.Add(cuboNuevo);
            }

            session.SetObject("CARRITO", carritoIds);
            return true;
        }

        // Borrar cubo del carrito
        public Task<bool> DeleteCuboAsync(int id)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            List<CuboCarritoSimple> carritoIds = session.GetObject<List<CuboCarritoSimple>>("CARRITO") ?? new List<CuboCarritoSimple>();

            CuboCarritoSimple cubo = carritoIds.Find(x => x.Id == id);
            if (cubo != null)
            {
                carritoIds.Remove(cubo);
                session.SetObject("CARRITO", carritoIds);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        // Obtener carrito completo (con datos de cubos y precios)
        public async Task<Carrito> GetCarritoAsync()
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            List<CuboCarritoSimple> carritoIds = session.GetObject<List<CuboCarritoSimple>>("CARRITO") ?? new List<CuboCarritoSimple>();

            Carrito carrito = new Carrito();
            carrito.cubos = new List<CuboCarrito>();

            if (carritoIds.Count == 0)
            {
                return carrito;
            }

            foreach (CuboCarritoSimple c in carritoIds)
            {
                // Llamada a la base de datos por cada cubo
                Cubo cubo = await _cuboRepository.GetCuboAsync(c.Id);

                if (cubo != null)
                {
                    CuboCarrito cuboCarrito = new CuboCarrito
                    {
                        Id = cubo.Id,
                        Nombre = cubo.Nombre,
                        Modelo = cubo.Modelo,
                        Marca = cubo.Marca,
                        Imagen = cubo.Imagen,
                        Precio = cubo.Precio,
                        Cantidad = c.Cantidad,
                        PrecioTotal = cubo.Precio * c.Cantidad
                    };
                    carrito.cubos.Add(cuboCarrito);
                }
            }

            return carrito;
        }

        // Método obligatorio por la interfaz original
        public Carrito GetCarrito()
        {
            return GetCarritoAsync().Result;
        }

    
    }
}