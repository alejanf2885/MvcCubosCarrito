using MvcCubosCarrito.Models;
using MvcCubosCarrito.Repositories.CubosRepo;

namespace MvcCubosCarrito.Services.CuboServ
{
    public class CuboService : ICuboService
    {
        private ICuboRepository _cuboRepo;

        public CuboService(ICuboRepository cuboRepo)
        {
            this._cuboRepo = cuboRepo;
        }

        public Task<bool> DeleteCuboAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarCuboAsync(string nombre, string modelo, string marca, string imagen, int precio)
        {
            throw new NotImplementedException();
        }

        public async Task<Cubo> GetCuboAsync(int id)
        {
            Cubo cubo = await this._cuboRepo.GetCuboAsync(id);

            return cubo;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            List<Cubo> cubos = await this._cuboRepo.GetCubosAsync();
            return cubos;
        }

        public Task<bool> InsertCuboAsync(string nombre, string modelo, string marca, string imagen, int precio)
        {
            throw new NotImplementedException();
        }
    }
}
