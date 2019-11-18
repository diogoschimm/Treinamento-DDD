using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnName("dataPedido")
                .HasColumnType("datetime");

            builder.Property(p => p.DataEntrega)
                .HasColumnName("dataEntrega")
                .HasColumnType("datetime");

            builder.Property(p => p.IdCliente)
                .IsRequired()
                .HasColumnName("idCliente");
            
            builder.Property(p => p.Observacao)
                .HasColumnName("observacao")
                .HasColumnName("varchar(500)");

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCliente);

            builder.Ignore(c => c.Errors);

            builder.ToTable("Pedidos");
        }
    }
}
