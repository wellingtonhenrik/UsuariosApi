using System.Net;
using System.Net.Mail;
using UsuariosApi.Infra.Messages.Settings;

namespace UsuariosApi.Infra.Messages.Helpers
{
    /// <summary>
    /// Classe para eecutar o envio de emails
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// Método para executar o envio de email
        /// </summary>
        public static void Send(string mailTo, string subjetc, string body)
        {
            var mailMessage = new MailMessage(EmailSettings.Account, mailTo);
            mailMessage.Subject = subjetc;
            mailMessage.Body = body;

            var smptClient = new SmtpClient(EmailSettings.Smpt, EmailSettings.Port);
            smptClient.Credentials = new NetworkCredential(EmailSettings.Account, EmailSettings.Password);
            smptClient.EnableSsl = true;
            smptClient.Send(mailMessage);
        }
    }
}
