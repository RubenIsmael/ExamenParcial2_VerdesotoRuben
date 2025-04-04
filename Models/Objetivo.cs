using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_parcia2.Models
{
    public class Objetivo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción del objetivo es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe asociar un objetivo a una campaña")]
        public int CampañaId { get; set; }

        [ForeignKey("CampañaId")]
        public Campaña Campaña { get; set; }
    }
}