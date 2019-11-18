using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate
{
    public class Pedido : EntidadeBase
    {
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int IdCliente { get; set; }
        public string Observacao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override bool IsConsistente()
        {
            this.ValidarDataPedido();
            this.ValidarDataEntrega();
            this.ValidarCliente();
            this.ValidarObservacao();

            this.ValidarItensPedido();

            return this.IsValid();
        }

        private void ValidarDataPedido()
        {
            if (this.DataPedido <= DateTime.Parse("01/01/1900"))
                this.AddError("A Data do Pedido não pode ser menor ou igual a 01/01/1900");

            if (this.DataPedido > DateTime.Now)
                this.AddError("A Data do Pedido não pode ser maior que a Data Atual do Sistema");
        }
        private void ValidarDataEntrega()
        {
            if (this.DataEntrega.HasValue)
            {
                if (this.DataEntrega.Value < this.DataPedido)
                    this.AddError("A Data da Entrega não pode ser menor que a Data do Pedido");
            }
        }
        private void ValidarCliente()
        {
            if (this.IdCliente <= 0)
                this.AddError("Cliente deve ser preenchido");
        }
        private void ValidarObservacao()
        {
            if (!string.IsNullOrEmpty(this.Observacao))
            {
                if (this.Observacao.Length > 500)
                    this.AddError("Observação não pode ter mais de 500 Caracteres");
            }
        }

        private void ValidarItensPedido()
        {
            if (this.ItensPedido == null)
                this.AddError("É necessário informar os Itens do Pedido");

            if (this.ItensPedido != null && this.ItensPedido.Count() == 0)
                this.AddError("É necessário informar pelo menos um Item de Pedido");

            if (this.ItensPedido != null)
            {
                foreach (var item in this.ItensPedido)
                {
                    if (!item.IsConsistente())
                    {
                        foreach (var erro in item.Errors)
                        {
                            this.AddError(erro);
                        }
                    }
                }
            }
        }

        public bool PedidoJaFoiEntregue()
        {
            return this.DataEntrega.HasValue;
        }
    }
}
