using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class CarritoCompras
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
