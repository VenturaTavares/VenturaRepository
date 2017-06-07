using DevStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DevStore.Infra.DataContext;
using System.Data.Entity;

namespace DevStore.Service.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable where TEntity : class
    {

        private DevStoreDataContext ctx = new DevStoreDataContext();

        public virtual void Adicionar(TEntity entity)
        {
            ctx.Set<TEntity>().Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public virtual void Deletar(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
           .Where(predicate).ToList()
           .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }


        public virtual void Deletar(TEntity entity)
        {
            ctx.Set<TEntity>().Remove(entity);

        }


        public void Dispose()
        {
            ctx.Dispose();
        }

        public IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return ObteTodos().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> ObterComFilhos(Expression<Func<TEntity, bool>> predicate, string children)
        {
            return ObteTodos().Include(children).Where(predicate).AsQueryable();
        }

        public TEntity ObterPrimeiro(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ObteTodos()
        {
            return ctx.Set<TEntity>();
        }

        public TEntity Pesquisar(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }
    }
}
