using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
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
    public class RecuperarSenhaTest
    {
        [Fact]
        public async Task RecuperarSenha_Post_Returns_OK()
        {
            //criando um usuario
            var criarContaTest = new CriarContaTest();
            var usuario = await criarContaTest.CriarConta_Post_Returns_Created();

            //criando a requisição
            var request = new RecuperarSenhaRequestModel()
            {
                Email = usuario.Email
            };

            //executando a recuperação da senha
            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("/api/usuarios/recuperar-senha", content);

            //resultado esperado OK(200)
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RecuperarSenha_Post_Returns_NotFound()
        {

            //criando a requisição
            var request = new RecuperarSenhaRequestModel()
            {
                Email = "TesteRecuperacaoDeSenha@gmail.com"
            };

            //executando a recuperação da senha
            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("/api/usuarios/recuperar-senha", content);

            //resultado esperado NotFound (404)
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
