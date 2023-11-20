using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Tests.Helpers;
using Xunit;

namespace UsuariosApi.Tests
{
    public class AutenticarTest
    {
        [Fact]
        public async Task<AutenticarResponseModel> Autenticar_Post_Returns_OK()
        {
            //realizar o cadastro de uma usuário

            var criarContaTest = new CriarContaTest();
            var usuario = await criarContaTest.CriarConta_Post_Returns_Created();
            
            //dados da requisição
            var request = new AutenticarRequestModel
            {
                Email = usuario.Email,
                Senha = usuario.Senha,
            };

            //autenticar o usuário 
            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("/api/usuarios/autenticar", content);

            //resultado esperado: OK(200)
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando os ados retornando pelo serviço de autenticação

            return TestHelper.ReadResponse<AutenticarResponseModel>(response);
        }

        [Fact]
        public async Task Autenticar_Post_Returns_Unauthorized()
        {
            //dados da requisição
            var request = new AutenticarRequestModel
            {
                Email = "UsuarioTeste@gmail.com.br",
                Senha = "@TesteUsuario123",
            };

            //autenticar o usuário 
            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("/api/usuarios/autenticar", content);

            //resultado esperado: UNAUTHORIZED(410)
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
