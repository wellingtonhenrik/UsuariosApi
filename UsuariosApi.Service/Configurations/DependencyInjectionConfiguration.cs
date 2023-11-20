using UsuariosApi.Application.Interfaces;
using UsuariosApi.Application.Services;
using UsuariosApi.Domain.Interfaces.Messages;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Domain.Interfaces.Services;
using UsuariosApi.Domain.Services;
using UsuariosApi.Infra.Data.Repositories;
using UsuariosApi.Infra.Messages;

namespace UsuariosApi.Service.Configurations
{
    /// <summary>
    /// Classe para configurar as injeções de dependencia do projeto
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IUsuarioMessage, UsuarioMessageProducer>();
        }
    }
}
