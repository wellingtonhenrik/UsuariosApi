using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Models;
using UsuariosApi.Domain.Exceptions;
using UsuariosApi.Service.Security;
using UsuariosApi.Service.Settings;

namespace UsuariosApi.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly TokenSecurity _tokenSecurity;
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuariosController(IOptions<JwtSettings> jwtSettings, TokenSecurity tokenSecurity, IUsuarioAppService usuarioAppService)
        {
            _jwtSettings = jwtSettings;
            _tokenSecurity = tokenSecurity;
            _usuarioAppService = usuarioAppService;
        }

        [Route("criar-conta")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponseModel), 201)]
        public IActionResult CriarConta(CriarContaRequestModel model)
        {
            try
            {
                var response = _usuarioAppService.CriarConta(model);
                return StatusCode(201, response);
            }
            catch (UsuarioJaCadastradoException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }

        }

        [Route("autenticar")]
        [HttpPost]
        [ProducesResponseType(typeof(AutenticarResponseModel), 200)]
        public IActionResult Autenticar(AutenticarRequestModel model)
        {
            try
            {
                var response = _usuarioAppService.Autenticar(model);
                response.AccesToken = _tokenSecurity.CreateToken(model.Email);
                response.DataHoraExpiracao = DateTime.UtcNow.AddHours(_jwtSettings.Value.ExpirationInHours);

                return StatusCode(200, response);
            }
            catch (AcessoNegadoException e)
            {
                return StatusCode(401, new { mensagem = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Route("recuperar-senha")]
        [HttpPost]
        [ProducesResponseType(typeof(RecuperarSenhaResponseModel), 200)]
        public IActionResult RecuperarSenha(RecuperarSenhaRequestModel model)
        {
            try
            {
                var response = _usuarioAppService.RecuperarSenha(model);
                return StatusCode(200, response);
            }
            catch (UsuarioNaoEncontradoException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Authorize]
        [Route("atualizar-dados")]
        [HttpPut]
        public IActionResult AtualizarDados(AtualizarDadosRequestModel model)
        {
            try
            {
                //capiturando o email do usuário contido no TOKEN
                var email = User.Identity.Name;

                //Atualizando os dados do usuário
                var response = _usuarioAppService.AtualizarDados(email, model);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }
    }
}
