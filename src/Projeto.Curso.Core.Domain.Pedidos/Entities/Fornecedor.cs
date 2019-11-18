using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Entities
{
    public class Fornecedor : Pessoa
    {
        public virtual ICollection<Produto> Produtos { get; set; }

        public override bool IsConsistente()
        {
            this.ValidarNome(tamanho: 150);
            this.ValidarDocumento();
            this.ValidarEmail(tamanho: 100);
            this.ValidarEndereco();

            return this.IsValid();
        }
    }
}
