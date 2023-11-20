﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Domain.Exceptions
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public override string Message => "Usuário não encontrado";
    }
}
