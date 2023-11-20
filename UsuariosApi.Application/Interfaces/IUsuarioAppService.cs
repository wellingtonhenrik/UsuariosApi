using UsuariosApi.Application.Models;

namespace UsuariosApi.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        /// <summary>
        /// Serviço da aplicação da autenticação de usuarios
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);

        /// <summary>
        /// Servico da aplicação para criação de usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);
        /// <summary>
        /// Serviço da aplicação para recuperar senha do usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RecuperarSenhaResponseModel RecuperarSenha(RecuperarSenhaRequestModel model);

        AtualizarDadosResponseModel AtualizarDados(string email ,AtualizarDadosRequestModel model);
    }
}
