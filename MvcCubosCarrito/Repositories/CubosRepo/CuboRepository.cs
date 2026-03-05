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

        public async Task<bool> InsertCuboAsync(int id, string nombre, string modelo, string marca, string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.Id = id;
            cubo.Nombre = nombre;
            cubo.Modelo = modelo;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;

            await this._context.AddAsync(cubo);

            int filasAfectadas = await _context.SaveChangesAsync();

            return filasAfectadas > 0;

        }
    }
}
