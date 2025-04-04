using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Examen_parcia2.Models
{
    public class Resultado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción del resultado es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        public string Descripcion { get; set; }

        public ICollection<Metrica> Metricas { get; set; } = new List<Metrica>();
    }
}