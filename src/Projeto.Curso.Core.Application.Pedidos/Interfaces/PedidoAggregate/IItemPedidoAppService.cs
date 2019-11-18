using Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Interfaces.PedidoAggregate
{
    public interface IItemPedidoAppService : IDisposable
    {
        ItemPedidoViewModel Save(ItemPedidoViewModel itemPedido);
        ItemPedidoViewModel Update(ItemPedidoViewModel itemPedido);
        ItemPedidoViewModel Delete(ItemPedidoViewModel itemPedido);

        IEnumerable<ItemPedidoViewModel> GetByIdPedido(int idPedido);
        ItemPedidoViewModel GetById(int id);
    }
}
