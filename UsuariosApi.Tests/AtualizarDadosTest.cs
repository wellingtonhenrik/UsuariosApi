using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models;
using UsuariosApi.Tests.Helpers;
using Xunit;

namespace UsuariosApi.Tests
{
    public class AtualizarDadosTest
    {
        [Fact]
        public async Task AtualizarDados_Put_Returns_OK()
        {
            //autenticar um usuário na API e obter os seus dados
            var autenticarTest = new AutenticarTest();
            var usuario = await autenticarTest.Autenticar_Post_Returns_OK();

            var request = new AtualizarDadosRequestModel
            {
                Nome = "TesteAtualizarDados",
                Senha = "@Teste123",
            };

            var content = TestHelper.CreateContent(request);
            var client = TestHelper.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", usuario.AccesToken);
            var response = await client.PutAsync("/api/usuarios/atualizar-dados", content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
