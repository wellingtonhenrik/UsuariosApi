using Bogus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Helpers;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Infra.Messages.Helpers;
using UsuariosApi.Infra.Messages.Settings;

namespace UsuariosApi.Infra.Messages
{
    public class UsuarioMessageConsumer : BackgroundService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection;
        private IModel _model;
        public UsuarioMessageConsumer(IUsuarioRepository usuarioRepository, IServiceProvider serviceProvider)
        {
            _usuarioRepository = usuarioRepository;
            _serviceProvider = serviceProvider;

            #region Conectando no servidor da mensageria

            var factory = new ConnectionFactory { Uri = new Uri(MessageSettings.Url) };

            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                  queue: MessageSettings.QueueName,
                  durable: true,
                  exclusive: false,
                  autoDelete: false,
                  arguments: null
                );
            #endregion
        }


        /// <summary>
        /// Método para deservolvermos a torinta de lleitura dos dados da fila 
        /// </summary>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //objeto capz de ler cada item da fila
            var consumer = new EventingBasicConsumer(_model);

            //fazendo a leitura de cada item da fila
            consumer.Received += (sender, args) =>
            {
                //lendo o item da fila (a primeira leitura é feita em bytes)
                var content = Encoding.UTF8.GetString(args.Body.ToArray());

                //serializando o conteudo lido de JSON para objeto

                var usuario = JsonConvert.DeserializeObject<Usuario>(content);

                try
                {
                    //Gerar uma nova senha para o usuário
                    var faker = new Faker();

                    var novaSenha = $"@{faker.Internet.Password(8)}{DateTime.Now.ToString("mm")}";

                    //Enviar uma email com a nova senha
                    var mailTo = usuario.Email;
                    var subject = "Recuperação de senha de usuário";
                    var body = $"Olá {usuario.Nome}! Sua nova senha de acesso é: {novaSenha}";

                    EmailHelper.Send(mailTo, subject, body);
                    usuario.Senha = MD5Helper.Encrypt(novaSenha);
                    _usuarioRepository.Update(usuario);

                    //retirar a mensagem da fila
                    //retirar o item da fila 

                    _model.BasicAck(args.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            };

            //finalizo o processo de leitura da fila 
            //false -> cada item lida da fila não será retirado automaticamente
            //cabe o desenvolvedor programar para remover o item da fila
            _model.BasicConsume(MessageSettings.QueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
