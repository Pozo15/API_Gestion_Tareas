using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiPrimeraAPI.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        public bool Estado { get; set; }

        [Required]
        [StringLength(20)]
        public string Prioridad { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        public DateTime FechaVencimiento { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Usuario? Usuario { get; set; }

        public int? CategoriaId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Categoria? Categoria { get; set; }
    }
}
