using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class Promocion
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(64, MinimumLength = 5, ErrorMessage = "El nombre corto debe tener entre 5 y 64 caracteres.")]
        public string NombreCorto { get; set; }

        [Required, StringLength(132, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 132 caracteres.")]
        public string Descripcion { get; set; }

        [Range(0, 90, ErrorMessage = "El porcentaje de descuento debe estar entre 0 y 90.")]
        public int PorcentajeDescuento { get; set; }

        public DateTime FechaInicia { get; set; }
        public DateTime FechaFinaliza { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
