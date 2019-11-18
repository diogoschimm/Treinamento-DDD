using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel()
        {
            this.Errors = new List<string>();
        }

        public int Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
