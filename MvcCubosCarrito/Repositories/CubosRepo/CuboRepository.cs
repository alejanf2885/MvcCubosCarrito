using Microsoft.EntityFrameworkCore;
using MvcCubosCarrito.Data;
using MvcCubosCarrito.Models;

namespace MvcCubosCarrito.Repositories.CubosRepo
{
    public class CuboRepository : ICuboRepository
    {

        private CuboContext _context;

        public CuboRepository(CuboContext context)
        {
            this._context = context;
        }

        public Task<bool> DeleteCuboAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarCuboAsync(string nombre, string modelo, string marca, string imagen, int precio)
        {
            throw new NotImplementedException();
        }

        public async Task<Cubo> GetCuboAsync(int idCubo)
        {
            var consulta = from datos in this._context.Cubos
                           where datos.Id == idCubo
                           select datos;

            Cubo cubo = await consulta.FirstOrDefaultAsync();
            return cubo;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            var consulta = from datos in this._context.Cubos
                           select datos;

            List<Cubo> cubos = await consulta.ToListAsync();

            return cubos;
        }

        public Task<bool> InsertCuboAsync(string nombre, string modelo, string marca, string imagen, int precio)
        {
            throw new NotImplementedException();
        }
    }
}
