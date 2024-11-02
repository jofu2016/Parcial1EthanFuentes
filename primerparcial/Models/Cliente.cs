using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 255 caracteres.")]
        public string Nombre { get; set; }

        [Required, EmailAddress(ErrorMessage = "Debe ser un correo válido.")]
        public string Correo { get; set; }

        [Required, MinLength(12, ErrorMessage = "La clave debe tener al menos 12 caracteres.")]
        public string Clave { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
