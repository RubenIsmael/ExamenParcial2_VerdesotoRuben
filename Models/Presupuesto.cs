using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_parcia2.Models
{
    public class Presupuesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto del presupuesto es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Debe asociar un presupuesto a una campaña")]
        public int CampañaId { get; set; }

        [ForeignKey("CampañaId")]
        public Campaña Campaña { get; set; }
    }
}
