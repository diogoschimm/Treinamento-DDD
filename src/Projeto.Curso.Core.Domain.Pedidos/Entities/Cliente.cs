using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Entities
{
    public class Cliente : Pessoa
    {
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override bool IsConsistente()
        {
            this.ValidarApelido(tamanho: 20);
            this.ValidarNome(tamanho: 100);
            this.ValidarDocumento();
            this.ValidarEmail(tamanho: 100);
            this.ValidarEndereco();

            return this.IsValid();
        }
    }
}
