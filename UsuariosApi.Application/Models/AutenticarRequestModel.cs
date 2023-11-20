using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Application.Models
{
    public class AutenticarRequestModel
    {
        [Required(ErrorMessage = "Informe {0}")]
        [EmailAddress(ErrorMessage ="Informe um endereço de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe {0}")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Senha deve conter letra maiuscula, minuscula e numero")]
        public string  Senha { get; set; }
    }
}
