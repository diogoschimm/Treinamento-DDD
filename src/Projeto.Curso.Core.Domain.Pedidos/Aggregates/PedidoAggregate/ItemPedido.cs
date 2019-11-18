using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate
{
    public class ItemPedido : EntidadeBase
    {
        public int QTD { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public override bool IsConsistente()
        {
            this.ValidarQTD(); 
            this.ValidarProduto();
            this.ValidarValor();

            return this.IsValid();
        }

        private void ValidarQTD()
        {
            if (this.QTD <= 0)
                this.AddError("QTD não pode ser menor ou igual a ZERO");
        } 
        private void ValidarProduto()
        {
            if (this.IdProduto <= 0)
                this.AddError("ID Produto deve ser preenchido");

            if (this.Produto == null)
                this.AddError("Produto deve ser preenchido");
        }
        private void ValidarValor()
        {
            if (this.Produto != null && this.Produto.Valor <= 0)
                this.AddError("Valor do Produto não pode ser menor ou igual a ZERO");
        }
    }
}
