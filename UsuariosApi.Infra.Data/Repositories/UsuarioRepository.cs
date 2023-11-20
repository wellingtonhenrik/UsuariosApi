using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Infra.Data.Contexts;

namespace UsuariosApi.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Get(string email)
        {
            //LAMBIDA
            //using (var context = new Context())
            //{
            //    return context.Usuario.FirstOrDefault(a => a.Email.Equals(email));
            //}

            var query = @"SELECT * FROM USUARIO WHERE EMAIL = @email";

            using (var contex = new Context())
            {
                return contex.Database.GetDbConnection().Query<Usuario>(query, new { email }).FirstOrDefault();
            }
        }

        public Usuario Get(string email, string senha)
        {
            //LAMBIDA
            //using (var context = new Context())
            //{
            //    return context.Usuario.FirstOrDefault(a => a.Email.Equals(email) && a.Senha.Equals(senha));
            //}

            var query = @"SELECT * FROM USUARIO WHERE EMAIL = @email AND SENHA = @senha";

            using (var context = new Context())
            {
                return context.Database.GetDbConnection().Query<Usuario>(query, new { email, senha }).FirstOrDefault();
            }
        }
    }
}
