using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Application.Models
{
    public class AtualizarDadosRequestModel
    {
        [MaxLength(100, ErrorMessage = "Informe máximo {1} caracteres no campo {0}")]
        [MinLength(2, ErrorMessage = "Informe minimo {1} caracteres no campo {0}")]
        public string? Nome { get; set; }

        [MaxLength(100, ErrorMessage = "Informe máximo {1} caracteres no campo {0}")]
        [MinLength(8, ErrorMessage = "Informe minimo {1} caracteres no campo {0}")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Senha deve conter letra maiuscula, minuscula e numero")]
        public string? Senha { get; set; }
    }
}
