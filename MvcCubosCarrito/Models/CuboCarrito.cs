using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCubosCarrito.Models
{
    public class CuboCarrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public string Imagen { get; set; }

        public int Precio { get; set; }

        public int PrecioTotal { get; set; }

        public int Cantidad { get; set; }
    }
}
