using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate
{
    public interface IItemPedidoService: IDisposable
    {
        ItemPedido Save(ItemPedido itemPedido);
        ItemPedido Update(ItemPedido itemPedido);
        ItemPedido Delete(ItemPedido itemPedido);

        IEnumerable<ItemPedido> GetByIdPedido(int idPedido);
        ItemPedido GetById(int id);

        IEnumerable<ItemPedido> Find(Expression<Func<ItemPedido, bool>> expression);
    }
}
