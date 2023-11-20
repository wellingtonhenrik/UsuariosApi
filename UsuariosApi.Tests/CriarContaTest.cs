using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Application.Models;
using UsuariosApi.Tests.Helpers;
using Xunit;

namespace UsuariosApi.Tests
{
    public class CriarContaTest
    {
        [Fact]
        public async Task<CriarContaRequestModel> CriarConta_Post_Returns_Created()
        {
            var faker = new Faker();

            var request = new CriarContaRequestModel { 
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123",
                ConfirmacaoSenha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("/api/usuarios/criar-conta",content);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            return request;
        }
        [Fact]
        public async Task CriarConta_Post_Returns_BadRequest()
        {
            //realizando o cadastro de um usuario
            var request = await CriarConta_Post_Returns_Created();

            //cadastrando o usuário novamente
            var content = TestHelper.CreateContent(request);
            var response = await TestHelper.CreateClient().PostAsync("api/usuarios/criar-conta", content);

            //verificando se o  resultado é BAD REQUEST
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }
}
