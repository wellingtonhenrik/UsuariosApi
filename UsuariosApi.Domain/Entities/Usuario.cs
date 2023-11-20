namespace UsuariosApi.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade 
    /// </summary>
    public class Usuario
    {
        public Guid? UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraUltimaAlteracao { get; set; }
    }
}
