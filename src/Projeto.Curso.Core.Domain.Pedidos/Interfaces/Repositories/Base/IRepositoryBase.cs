using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntidadeBase
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        int Commit();
    }
}
