using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Service.Interfaces
{
    public interface IRepositorio <TEntity> where TEntity : class
    {
        IQueryable<TEntity> ObteTodos();
        IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        TEntity Pesquisar(params object[] key);
        TEntity ObterPrimeiro(Expression<Func<TEntity, bool>> predicate);
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Deletar(Func<TEntity, bool> predicate);
        void Commit();
        void Dispose();
    }
}
