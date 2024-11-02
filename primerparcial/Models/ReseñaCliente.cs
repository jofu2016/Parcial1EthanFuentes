using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class ReseñaCliente
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int ProductoId { get; set; }

        [Range(0, 5, ErrorMessage = "La clasificación debe estar entre 0 y 5.")]
        public int ValorClasificacion { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "El comentario debe tener entre 5 y 255 caracteres.")]
        public string Comentario { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
