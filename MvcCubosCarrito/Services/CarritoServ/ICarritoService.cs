using MvcCubosCarrito.Models;

namespace MvcCubosCarrito.Services.CarritoServ
{
    public interface ICarritoService
    {
        Task<bool> AddCubo(int id);

        Task<bool> DeleteCubo(int id);

        Carrito GetCarrito();
    }
}
