 namespace UsuariosApi.Service.Settings
{
    //Classe para capturar as configurações do arquivo /appsetings.json
    public class JwtSettings
    { 
        public string? SecretKey { get; set; }
        public int ExpirationInHours { get; set; }
    }
}
