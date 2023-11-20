using UsuariosApi.Infra.Messages;
using UsuariosApi.Service.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddRouting(r => r.LowercaseUrls = true);


//chamando configure da swagger
SwaggerConfiguration.Configure(builder);
//chamando configure da autenticação com JWT
JwtConfiguration.Configure(builder);
//chamando configure da injeção de dependencia
DependencyInjectionConfiguration.Configure(builder);

//registrando a classe consumer do RabbitMQ

//comentado pois no MYASP gratuito não roda esse serviço
//builder.Services.AddHostedService<UsuarioMessageConsumer>();

//configurando CORS da API
CorsConfiguration.Configure(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Confirmando que usará o CORS
CorsConfiguration.UseCors(app);

app.Run();

//Tornando classe program publica
public partial class Program { }