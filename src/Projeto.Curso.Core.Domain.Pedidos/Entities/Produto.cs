using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Entities
{
    public class Produto : EntidadeBase
    {
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override bool IsConsistente()
        {
            this.ValidarApelido();
            this.ValidarNome();
            this.ValidarValor();
            this.ValidarUnidade();
            this.ValidarFornecedor();

            return this.IsValid();
        }

        private void ValidarApelido()
        {
            if (string.IsNullOrEmpty(this.Apelido))
                this.AddError("Apelido não pode ser em Branco");

            if (this.Apelido != null && this.Apelido.Length > 100)
                this.AddError("Apelido não pode ter mais de 100 Caracteres");
        } 
        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(this.Nome))
                this.AddError("Nome não pode ser em Branco");

            if (this.Nome != null && this.Nome.Length > 100)
                this.AddError("Nome do Produto não pode ter mais de 100 Caracteres");
        }
        private void ValidarValor()
        {
            if (this.Valor <= 0)
                this.AddError("Valor não pode ser menor ou igual a ZERO");
        }
        private void ValidarUnidade()
        {
            if (string.IsNullOrEmpty(this.Unidade))
                this.AddError("Unidade não pode ser em Branco");

            var listaUnidades = new List<string> { "KL", "GR", "MT", "CM", "QT" };
            if (this.Unidade != null && listaUnidades.Where(u => u == this.Unidade).Any())
                this.AddError("Unidade inválida, deve ser KL, GR, MT, CM ou QT");
        }
        private void ValidarFornecedor()
        {
            if (this.IdFornecedor <= 0)
                this.AddError("Fornecedor deve ser preenchido");
        }
    }
}
