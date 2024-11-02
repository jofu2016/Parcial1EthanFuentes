using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 7, ErrorMessage = "La provincia debe estar entre 1 y 7.")]
        public int ProvinciaId { get; set; }

        public int CantonId { get; set; }
        public int DistritoId { get; set; }

        [Required]
        public string DireccionExacta { get; set; }

        public string CodigoPostal { get; set; }
        public int PaisId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
