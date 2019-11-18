using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.Errors = new List<string>();
        }

        public int Id { get; set; }
        public List<string> Errors { get; set; }
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
    }
}
