using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;

namespace UsuariosApi.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para definir métodos de envio de mensagens / notificações 
    /// de usuário. Está interface será implementada por uma infraestrutura de mensageria com RabbitMQ
    /// </summary>
    public interface IUsuarioMessage
    {

        /// <summary>
        /// Metodo para enviar uma notificação para a fila da mensageria
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        void EnviarMensagemDeRecuperarcaoDeSenha(Usuario usuario);
    }
}
