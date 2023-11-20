using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Interfaces.Messages;
using UsuariosApi.Infra.Messages.Settings;

namespace UsuariosApi.Infra.Messages
{
    public class UsuarioMessageProducer : IUsuarioMessage
    {
        public void EnviarMensagemDeRecuperarcaoDeSenha(Usuario usuario)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(MessageSettings.Url),
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    //Criar a fila onde iremos escrever as mensagens de recuperação
                    //de senha de usuários
                    model.QueueDeclare(
                        queue: MessageSettings.QueueName, //nome da fila
                        durable: true, //fila não ira perder o seu conteudo mesmo que o servidor seja parado
                        exclusive: false,//fila aceia multiplas conexões
                        autoDelete: false, //os itens da fila não são removidos automaticamente
                        arguments: null
                        );

                    //Escrevendo conteudo na fila
                    //(dados do usuario que solicitou a recuperação da senha)

                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: MessageSettings.QueueName,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usuario))
                        );
                }
            }

        }
    }
}
