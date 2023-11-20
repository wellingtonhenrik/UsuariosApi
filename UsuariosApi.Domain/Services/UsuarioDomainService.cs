using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Exceptions;
using UsuariosApi.Domain.Helpers;
using UsuariosApi.Domain.Interfaces.Messages;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Domain.Interfaces.Services;

namespace UsuariosApi.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioMessage _usuarioMessage;
        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IUsuarioMessage usuarioMessage)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioMessage = usuarioMessage;
        }
        public Usuario AtualizarDados(string email, string nome, string senha)
        {
            var usuario = _usuarioRepository.Get(email);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            if (!string.IsNullOrWhiteSpace(nome))
                usuario.Nome = nome;

            if (!string.IsNullOrWhiteSpace(senha))
                usuario.Senha = MD5Helper.Encrypt(senha);

            _usuarioRepository.Update(usuario);

            return usuario;
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = _usuarioRepository.Get(email, MD5Helper.Encrypt(senha));

            if (usuario == null)
                throw new AcessoNegadoException();

            return usuario;
        }

        public void CriarUsuario(Usuario usuario)
        {
            if (_usuarioRepository.Get(usuario.Email) != null)
                throw new UsuarioJaCadastradoException();

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            _usuarioRepository.Add(usuario);
        }

        public Usuario RecuperarSenha(string email)
        {
            var usuario = _usuarioRepository.Get(email);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException();

            //Enviar uma notificação de recuperação de senha para a mensageria
            _usuarioMessage.EnviarMensagemDeRecuperarcaoDeSenha(usuario);
            return usuario;
        }
    }
}
