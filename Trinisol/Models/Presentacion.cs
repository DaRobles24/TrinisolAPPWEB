namespace Trinisol.Models
{
    public class Presentacion
    {
        public int Id { get; set; }

        public string NombrePresentacion { get; set; } = string.Empty;

        public decimal PrecioUnitario { get; set; } = 0;
        public decimal PrecioMayorista { get; set; } = 0;

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
