using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Domain.Exceptions
{
    public class UsuarioJaCadastradoException : Exception
    {
        public override string Message => "Já existe um usuário com esse email"; 
    }
}
