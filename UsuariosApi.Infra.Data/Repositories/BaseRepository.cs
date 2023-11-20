using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Interfaces.Repositories;
using UsuariosApi.Infra.Data.Contexts;

namespace UsuariosApi.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var contex = new Context())
            {
                contex.Remove(entity);
                contex.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity GetById(Guid id)
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().FirstOrDefault();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
