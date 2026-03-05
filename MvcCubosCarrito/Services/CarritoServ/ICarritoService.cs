using MvcCubosCarrito.Models;

namespace MvcCubosCarrito.Services.CarritoServ
{
    public interface ICarritoService
    {
        Task<bool> AddCuboAsync(int id);

        Task<bool> DeleteCuboAsync(int id);

        Carrito GetCarrito();

    }
}
