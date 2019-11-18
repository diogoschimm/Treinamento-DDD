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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoService _itemPedidoService;

        public PedidoService(IPedidoRepository pedidoRepository, IItemPedidoService itemPedidoService)
        {
            this._pedidoRepository = pedidoRepository;
            this._itemPedidoService = itemPedidoService;
        }

        public Pedido Save(Pedido pedido)
        {
            if (!pedido.IsConsistente())
                return pedido;

            if (this._pedidoRepository.Find(x => x.IdCliente == pedido.IdCliente && !x.DataEntrega.HasValue).Count() > 0)
                pedido.AddError("Já existe pedido aberto para este cliente");

            if (pedido.IsValid())
                this._pedidoRepository.Save(pedido);

            return pedido;
        }
        public Pedido Update(Pedido pedido)
        {
            if (!pedido.IsConsistente())
                return pedido;

            var result = this.GetById(pedido.Id);
            if (result == null)
                pedido.AddError("Pedido não localizado no sistema");

            if (result != null && result.PedidoJaFoiEntregue())
                pedido.AddError("Pedido já foi entregue e não pode ser alterado");

            if (pedido.IsValid())
                this._pedidoRepository.Update(pedido);

            return pedido;
        }
        public Pedido Delete(Pedido pedido)
        {
            var result = this.GetById(pedido.Id);
            if (result == null)
                pedido.AddError("Pedido não localizado no sistema");

            if (result != null && result.PedidoJaFoiEntregue())
                pedido.AddError("Pedido já foi entregue e não pode ser excluído");

            if (pedido.IsValid())
            {
                foreach (var item in this._itemPedidoService.GetByIdPedido(pedido.Id))
                {
                    this._itemPedidoService.Delete(item);
                }

                this._pedidoRepository.Delete(pedido);
            }

            return pedido;
        }

        public IEnumerable<Pedido> GetAll()
        {
            return this._pedidoRepository.GetAll();
        }
        public Pedido GetById(int id)
        {
            return this._pedidoRepository.GetById(id);
        }
        public IEnumerable<Pedido> Find(Expression<Func<Pedido, bool>> expression)
        {
            return this._pedidoRepository.Find(expression);
        }

        public void Dispose()
        {
            this._pedidoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
