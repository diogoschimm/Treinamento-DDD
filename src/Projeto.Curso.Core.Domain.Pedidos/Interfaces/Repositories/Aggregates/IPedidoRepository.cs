using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Aggregates
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        void AddItemPedido(ItemPedido itemPedido);
        void UpdateItemPedido(ItemPedido itemPedido);
        void DeleteItemPedido(ItemPedido itemPedido);

        ItemPedido GetItemPedidoById(int id);
        IEnumerable<ItemPedido> GetItensPedido(int idPedido);
        IEnumerable<ItemPedido> FindItemPedido(Expression<Func<ItemPedido, bool>> expression);
    }
}
