using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class MetodoPagoCliente
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int TipoPagoId { get; set; }

        [Required, StringLength(255, MinimumLength = 5, ErrorMessage = "El nombre del proveedor debe tener entre 5 y 255 caracteres.")]
        public string NombreProveedor { get; set; }

        [Required, StringLength(24, ErrorMessage = "La cuenta debe tener un máximo de 24 caracteres.")]
        public string Cuenta { get; set; }

        public DateTime FechaExpira { get; set; }

        public bool PorDefecto { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
