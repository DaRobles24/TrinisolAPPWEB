using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trinisol.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string TipoCliente { get; set; } = string.Empty;
        public string Contacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string DireccionGoogleMaps { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;

        // Relación con facturas
        public List<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
