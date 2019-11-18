using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Produto Save(Produto produto);
        Produto Update(Produto produto);
        Produto Delete(Produto produto);

        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        Produto GetByName(string nome);
        Produto GetByApelido(string apelido);

        IEnumerable<Produto> Find(Expression<Func<Produto, bool>> expression);
    }
}
