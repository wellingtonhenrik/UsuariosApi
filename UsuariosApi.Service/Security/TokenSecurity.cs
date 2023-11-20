using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Service.Settings;

namespace UsuariosApi.Service.Security
{
    public class TokenSecurity
    {
        //Atributo para receber as configurações definidas no arquivo /appsettings.json
        private readonly IOptions<JwtSettings>? _jwtSettings;
        public TokenSecurity(IOptions<JwtSettings>? jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string? CreateToken(string userName)
        {
            //gerando a assinatura antifalsificação do token (VERIFY SIGNATURE)
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings?.Value.SecretKey);

            //preenchendo o conteudo do TOKEN (PAYLOAD)
            var tokenDescription = new SecurityTokenDescriptor
            {
                //identificação do nome do usuario para o qual o token está sendo gerado
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userName) }),

                //definindo a data de expiração do token
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Value.ExpirationInHours),

                //assinando o tokem (antifalsificação)
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            //gerando e retornando o token 
            var acessToken = tokenHandle.CreateToken(tokenDescription);

            return tokenHandle.WriteToken(acessToken);
        }
    }
}
