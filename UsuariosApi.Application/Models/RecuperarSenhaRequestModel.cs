using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Application.Models
{
    public class RecuperarSenhaRequestModel
    {
        [Required(ErrorMessage = "Informe campo {0}")]
        [EmailAddress(ErrorMessage ="Informe endereço de email válido")]  
        public string? Email { get; set; }
    }
}
