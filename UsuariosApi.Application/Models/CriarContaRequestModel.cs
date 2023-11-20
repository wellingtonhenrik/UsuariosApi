using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Application.Models
{
    /// <summary>
    /// Modelo de dados da requisição do endipoint POST /api/usuarios/criar-conta
    /// </summary>
    public class CriarContaRequestModel
    {
        [MaxLength(100 , ErrorMessage ="Informe máximo {1} caracteres")]
        [MinLength(2 , ErrorMessage ="Informe minimo {1} caracteres")]
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string? Nome { get; set; }

        [MaxLength(100, ErrorMessage = "Informe máximo {1} caracteres")]
        [MinLength(8, ErrorMessage = "Informe minimo {1} caracteres")]
        [Required(ErrorMessage = "Informe o campo {0}")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string? Email { get; set; }

        [MaxLength(25, ErrorMessage = "Informe máximo {1} caracteres")]
        [MinLength(8, ErrorMessage = "Informe minimo {1} caracteres")]
        [Required(ErrorMessage = "Informe o campo {0}")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Senha deve conter letra maiuscula, minuscula e numero")]
        public string? Senha { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Senha deve conter letra maiuscula, minuscula e numero")]
        [Compare("Senha", ErrorMessage = "Campo senha não bate com o campo confirmação de senha ")]
        public string? ConfirmacaoSenha { get; set; }
    }
}
