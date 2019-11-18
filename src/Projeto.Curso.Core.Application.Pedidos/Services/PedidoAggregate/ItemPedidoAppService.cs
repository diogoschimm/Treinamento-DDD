using AutoMapper;
using Projeto.Curso.Core.Application.Pedidos.Interfaces.PedidoAggregate;
using Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Services.PedidoAggregate
{
    public class ItemPedidoAppService : IItemPedidoAppService
    {
        private readonly IItemPedidoService _itemPedidoService;
        private readonly IMapper _mapper;

        public ItemPedidoAppService(IItemPedidoService itemPedidoService, IMapper mapper)
        {
            this._itemPedidoService = itemPedidoService;
            this._mapper = mapper;
        }

        public ItemPedidoViewModel Save(ItemPedidoViewModel itemPedido)
        {
            return this._mapper.Map<ItemPedidoViewModel>(this._itemPedidoService.Save(this._mapper.Map<ItemPedido>(itemPedido)));
        }
        public ItemPedidoViewModel Update(ItemPedidoViewModel itemPedido)
        {
            return this._mapper.Map<ItemPedidoViewModel>(this._itemPedidoService.Update(this._mapper.Map<ItemPedido>(itemPedido)));
        }
        public ItemPedidoViewModel Delete(ItemPedidoViewModel itemPedido)
        {
            return this._mapper.Map<ItemPedidoViewModel>(this._itemPedidoService.Delete(this._mapper.Map<ItemPedido>(itemPedido)));
        }

        public IEnumerable<ItemPedidoViewModel> GetByIdPedido(int idPedido)
        {
            return this._mapper.Map<IEnumerable<ItemPedidoViewModel>>(this._itemPedidoService.GetByIdPedido(idPedido));
        }
        public ItemPedidoViewModel GetById(int id)
        {
            return this._mapper.Map<ItemPedidoViewModel>(this._itemPedidoService.GetById(id));
        }

        public void Dispose()
        {
            this._itemPedidoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
