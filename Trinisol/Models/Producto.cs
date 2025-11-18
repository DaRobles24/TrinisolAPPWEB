using System.Collections.Generic;

namespace Trinisol.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        // Relación con Presentaciones
        public ICollection<Presentacion> Presentaciones { get; set; } = new List<Presentacion>();
    }
}
