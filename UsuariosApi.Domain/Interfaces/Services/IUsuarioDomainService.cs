using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;

namespace UsuariosApi.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarUsuario(Usuario usuario);
        Usuario Autenticar(string email, string senha);
        Usuario RecuperarSenha(string email);
        Usuario AtualizarDados(string email, string nome, string senha);
    }
}
