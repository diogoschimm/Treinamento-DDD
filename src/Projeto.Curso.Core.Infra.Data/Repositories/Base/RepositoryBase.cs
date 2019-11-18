using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Base;
using Projeto.Curso.Core.Domain.Shared.Entities;
using Projeto.Curso.Core.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity: EntidadeBase
    {
        protected PedidosContext pedidosContext;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(PedidosContext pedidosContext )
        {
            this.pedidosContext = pedidosContext;
            this.DbSet = pedidosContext.Set<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            this.DbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            this.DbSet.Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        } 
        public virtual TEntity GetById(int id)
        {
            return this.DbSet.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.AsNoTracking().Where(expression);
        }

        public int Commit()
        {
            return this.pedidosContext.SaveChanges();
        }
        public void Dispose()
        {
            this.pedidosContext.Dispose();
        }

        protected string GetStringConnection()
        {
            var cfg = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
            return cfg.GetConnectionString("DefaultConnection");
        }
    }
}
