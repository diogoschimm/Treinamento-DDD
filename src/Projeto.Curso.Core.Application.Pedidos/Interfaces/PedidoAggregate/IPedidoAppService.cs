using Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Interfaces.PedidoAggregate
{
    public interface IPedidoAppService : IDisposable
    {
        PedidoViewModel Save(PedidoViewModel pedido);
        PedidoViewModel Update(PedidoViewModel pedido);
        PedidoViewModel Delete(PedidoViewModel pedido);

        IEnumerable<PedidoViewModel> GetAll();
        PedidoViewModel GetById(int id);
    }
}
