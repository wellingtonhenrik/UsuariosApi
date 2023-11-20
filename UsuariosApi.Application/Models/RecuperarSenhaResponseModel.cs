namespace UsuariosApi.Application.Models
{
    public class RecuperarSenhaResponseModel
    {
        public Guid? Id { get; set; }
        public string?  Nome { get; set; }
        public string? Email { get; set; }
        public string? DataHoraRecuperacaoDeSenha { get; set; }
    }
}
