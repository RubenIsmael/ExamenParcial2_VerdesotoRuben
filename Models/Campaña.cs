using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_parcia2.Models
{
    public class Campaña
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la campaña es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        public ICollection<Objetivo> Objetivos { get; set; } = new List<Objetivo>();
        public ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
        public Presupuesto Presupuesto { get; set; }
    }
}