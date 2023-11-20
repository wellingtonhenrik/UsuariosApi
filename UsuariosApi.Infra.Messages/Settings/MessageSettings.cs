using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Infra.Messages.Settings
{
    public class MessageSettings
    {
        //Endereço da mensageria RabbitMQ
        public static string Url => "amqps://fbagnduu:MqT5GD75XwOWLX0bqbWIByIOyjsqAssL@chimpanzee.rmq.cloudamqp.com/fbagnduu";
        //Nome da fila
        public static string QueueName => "recuperação_de_senha";
    }
}
