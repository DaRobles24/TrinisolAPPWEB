using System;
using System.Collections.Generic;
using System.Linq;
using Trinisol.Models.Dto;

namespace Trinisol.Models.ViewModels
{
    public class FacturaViewModel
    {
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

        public List<FacturaItemViewModel> Items { get; set; } = new();

        public string MetodoPago { get; set; }

        // ---------- NUEVO: listas completas ----------
        public IEnumerable<ClienteDto> Clientes { get; set; }
        public IEnumerable<ProductoDto> Productos { get; set; }
        public IEnumerable<PresentacionDto> Presentaciones { get; set; }

        // ---------- Cálculos ----------
        public decimal SaldoPendiente { get; set; }
        public decimal Pago { get; set; }

        public decimal Subtotal => (SaldoPendiente + Items.Sum(x => x.Total));
        public decimal TotalPendiente => Subtotal - Pago;
    }
}
