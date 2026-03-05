using MvcCubosCarrito.Models;

namespace MvcCubosCarrito.Services.CuboServ
{
    public interface ICuboService
    {
        Task<List<Cubo>> GetCubosAsync();

        Task<Cubo> GetCuboAsync(int id);

        Task<bool> InsertCuboAsync
            (string nombre, string modelo, string marca, string imagen, int precio);

        Task<bool> EditarCuboAsync
            (string nombre, string modelo, string marca, string imagen, int precio);

        Task<bool> DeleteCuboAsync(int id);
    }
}
