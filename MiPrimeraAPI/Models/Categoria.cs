using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiPrimeraAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string Seccion { get; set; } = string.Empty;

        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Tarea>? Tareas { get; set; }
    }
}
