using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.QTD)
                .IsRequired()
                .HasColumnName("qtd");

            builder.Property(i => i.IdPedido)
                .IsRequired()
                .HasColumnName("idPedido");

            builder.Property(i => i.IdProduto)
                .IsRequired()
                .HasColumnName("idProduto");

            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.IdPedido);

            builder.HasOne(i => i.Produto)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(i => i.IdProduto);

            builder.Ignore(i => i.Errors);

            builder.ToTable("ItensPedido");
        }
    }
}
