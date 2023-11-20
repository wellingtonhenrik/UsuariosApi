using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Tests.Helpers
{
    public static class TestHelper
    {
        /// <summary>
        /// Método para cliar um CLIENT HTTP para acessar a API
        /// </summary>
        public static HttpClient CreateClient()
        {
            return new WebApplicationFactory<Program>().CreateClient();
        }

        /// <summary>
        /// Método para serializar um conteudo JSON que será 
        /// enviado para o serviço de uma API
        /// </summary>
        public static StringContent CreateContent(object request)
        {
            return new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Método para ler e deserializar o retorno da API 
        /// após a execução de uma chamada HTTP (POST, PUT, DELETE, GET etc)
        /// </summary>
        public static T ReadResponse<T>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
        }
    }
}
