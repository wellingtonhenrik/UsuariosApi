using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Models;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Interfaces.Services;

namespace UsuariosApi.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public AtualizarDadosResponseModel AtualizarDados(string email, AtualizarDadosRequestModel model)
        {
            var usuario = _usuarioDomainService.AtualizarDados(email, model.Nome, model.Senha);

            return new AtualizarDadosResponseModel
            {
                Nome = usuario.Nome,
                DataHoraAtualizacao = DateTime.Now,
                Email = email,
                Id = usuario.UsuarioId
            };
        }

        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            var usuario = _usuarioDomainService.Autenticar(model.Email, model.Senha);

            return new AutenticarResponseModel
            {
                Id = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraAcesso = DateTime.Now,
            };
        }

        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {
            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                DataHoraCriacao = DateTime.Now,
                Senha = model.Senha,
                UsuarioId = Guid.NewGuid(),
            };

            _usuarioDomainService.CriarUsuario(usuario);

            return new CriarContaResponseModel
            {
                DataHoraCriacao = usuario.DataHoraCriacao,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Id = usuario.UsuarioId
            };
        }

        public RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(model.Email);

            return new RecuperarSenhaResponseModel
            {
                Email = usuario.Email,
                DataHoraRecuperacaoDeSenha = DateTime.Now.ToString(),
                Id = usuario.UsuarioId,
                Nome = usuario.Nome
            };
        }
    }
}
