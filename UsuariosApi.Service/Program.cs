using UsuariosApi.Infra.Messages;
using UsuariosApi.Service.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRouting(r => r.LowercaseUrls = true);


//chamando configure da swagger
SwaggerConfiguration.Configure(builder);
//chamando configure da autentica��o com JWT
JwtConfiguration.Configure(builder);
//chamando configure da inje��o de dependencia
DependencyInjectionConfiguration.Configure(builder);

//registrando a classe consumer do RabbitMQ

//comentado pois no MYASP gratuito n�o roda esse servi�o
//builder.Services.AddHostedService<UsuarioMessageConsumer>();

//configurando CORS da API
CorsConfiguration.Configure(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Confirmando que usar� o CORS
CorsConfiguration.UseCors(app);

app.Run();

//Tornando classe program publica
public partial class Program { }