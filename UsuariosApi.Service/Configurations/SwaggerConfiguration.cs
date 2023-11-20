using Microsoft.OpenApi.Models;

namespace UsuariosApi.Service.Configurations
{
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Método para 
        /// </summary>
        /// <param name="builder"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para controle de",
                    Description = "",
                    Version= "v1",
                    Contact = new OpenApiContact 
                    { 
                        Email = "wellingtonhenrik13@gmail.com",
                        Name = "APIUsuarios",
                    }

                });
            });
        }
    }
}
