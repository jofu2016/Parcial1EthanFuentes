﻿using System;
using System.ComponentModel.DataAnnotations;

namespace primerparcial.Models
{
    public class TipoPago
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(132, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 132 caracteres.")]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
