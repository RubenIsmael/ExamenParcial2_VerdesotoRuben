using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Examen_parcia2.Models
{
    public class Metrica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la métrica es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El valor de la métrica es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser un número positivo")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Debe asociar una métrica a un resultado")]
        public int ResultadoId { get; set; }

        [ForeignKey("ResultadoId")]
        public Resultado Resultado { get; set; }
    }
}
