using System.ComponentModel.DataAnnotations;

namespace MiPrimeraAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
