using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate
{
    public interface IPedidoService: IDisposable
    {
        Pedido Save(Pedido pedido);
        Pedido Update(Pedido pedido);
        Pedido Delete(Pedido pedido);

        IEnumerable<Pedido> GetAll();
        Pedido GetById(int id);

        IEnumerable<Pedido> Find(Expression<Func<Pedido, bool>> expression);
    }
}
