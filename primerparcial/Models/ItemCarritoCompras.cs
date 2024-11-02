using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class ItemCarritoCompras
    {
        [Key]
        public int Id { get; set; }

        public int CarritoComprasId { get; set; }
        public int ProductoId { get; set; }

        [Range(0, 9999, ErrorMessage = "La cantidad debe estar entre 0 y 9,999.")]
        public int Cantidad { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
