using Trinisol.Models;

public class ProductoFactura
{
    public int Id { get; set; }

    public int FacturaId { get; set; }
    public Factura Factura { get; set; } = null!;

    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    public int PresentacionId { get; set; }
    public Presentacion Presentacion { get; set; } = null!;

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    // Calcula automáticamente el subtotal
    public decimal Subtotal => Cantidad * PrecioUnitario;
}
