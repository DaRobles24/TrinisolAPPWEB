using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trinisol.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public decimal SaldoPendiente { get; set; } = 0;
        public decimal Pago { get; set; } = 0;
        public string MetodoPago { get; set; } = "Sinpe";
        public int NumeroFactura { get; set; } // Opcional si querés controlar numeración


        // Lista de productos facturados
        public List<ProductoFactura> ProductosFacturados { get; set; } = new List<ProductoFactura>();
    }
}
