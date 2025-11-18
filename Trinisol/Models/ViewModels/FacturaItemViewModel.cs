namespace Trinisol.Models.ViewModels
{
    public class FacturaItemViewModel
    {
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; } // ← LO QUE FALTABA
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Cantidad * PrecioUnitario;
    }
}
