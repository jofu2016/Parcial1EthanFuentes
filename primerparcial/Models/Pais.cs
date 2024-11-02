using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(132, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 132 caracteres.")]
        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
