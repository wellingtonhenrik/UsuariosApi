using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApi.Infra.Messages.Settings
{
    public class EmailSettings
    {
        public static string Account => "TesteDesenvolvimento_sc@outlook.com";
        public static string Password => "T2st2D2Senv";
        public  static string Smpt => "smpt-mail.outlook.com";
        public static int Port => 587;
    }
}
