using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsuariosApi.Service.Security;
using UsuariosApi.Service.Settings;

namespace UsuariosApi.Service.Configurations
{
    public class JwtConfiguration
    {

        /// <summary>
        /// definindo a politica de autenticação do projeto
        /// </summary>
        /// <param name="builder"></param>
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(

            bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(builder.Configuration
                    .GetSection("JwtSettings")
                    .GetSection("SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //mapeando as classes criadas no projeto para o JWT
            //aqui estamos configurando a classe JwtSettings para capturar as configurações do appsettings.json
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            //registrando a classe TokenSecurity
            builder.Services.AddTransient<TokenSecurity>();
        }

    }
}
