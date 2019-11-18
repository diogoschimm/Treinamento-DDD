using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Aggregates;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Services.PedidoAggregate
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ItemPedidoService(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public ItemPedido Save(ItemPedido itemPedido)
        {
            if (!itemPedido.IsConsistente())
                return itemPedido;

            if (itemPedido.IsValid())
                this._pedidoRepository.AddItemPedido(itemPedido);

            return itemPedido;
        }

        public ItemPedido Update(ItemPedido itemPedido)
        {
            if (!itemPedido.IsConsistente())
                return itemPedido;

            if (itemPedido.IdPedido <= 0)
                itemPedido.AddError("Para atualizar o Item do Pedido é necessário informar o Pedido");

            var resultItemPedido = this._pedidoRepository.GetItensPedido(itemPedido.IdPedido).FirstOrDefault(x => x.Id != itemPedido.Id && x.IdProduto == itemPedido.IdProduto);
            if (resultItemPedido != null)
                itemPedido.AddError("Já existe o Produto cadastrado para este Pedido");

            if (itemPedido.IsValid())
                this._pedidoRepository.UpdateItemPedido(itemPedido);

            return itemPedido;
        }
        public ItemPedido Delete(ItemPedido itemPedido)
        {
            this._pedidoRepository.DeleteItemPedido(itemPedido);
            return itemPedido;
        }

        public IEnumerable<ItemPedido> GetByIdPedido(int idPedido)
        {
            return this._pedidoRepository.GetItensPedido(idPedido);
        }
        public ItemPedido GetById(int id)
        {
            return this._pedidoRepository.GetItemPedidoById(id);
        }
        public IEnumerable<ItemPedido> Find(Expression<Func<ItemPedido, bool>> expression)
        {
            return this._pedidoRepository.FindItemPedido(expression);
        }

        public void Dispose()
        {
            this._pedidoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
