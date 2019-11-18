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
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoAppService(IPedidoService pedidoService, IMapper mapper)
        {
            this._pedidoService = pedidoService;
            this._mapper = mapper;
        }

        public PedidoViewModel Save(PedidoViewModel pedido)
        {
            return this._mapper.Map<PedidoViewModel>(this._pedidoService.Save(this._mapper.Map<Pedido>(pedido)));
        }
        public PedidoViewModel Update(PedidoViewModel pedido)
        {
            return this._mapper.Map<PedidoViewModel>(this._pedidoService.Update(this._mapper.Map<Pedido>(pedido)));
        }
        public PedidoViewModel Delete(PedidoViewModel pedido)
        {
            return this._mapper.Map<PedidoViewModel>(this._pedidoService.Delete(this._mapper.Map<Pedido>(pedido)));
        }

        public IEnumerable<PedidoViewModel> GetAll()
        {
            return this._mapper.Map<IEnumerable<PedidoViewModel>>(this._pedidoService.GetAll());
        }
        public PedidoViewModel GetById(int id)
        {
            return this._mapper.Map<PedidoViewModel>(this._pedidoService.GetById(id));
        }

        public void Dispose()
        {
            this._pedidoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
