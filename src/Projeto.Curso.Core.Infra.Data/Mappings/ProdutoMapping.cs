using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Apelido)
                .IsRequired()
                .HasColumnName("apelido")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("nomeProduto")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnName("valor")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Unidade)
                .IsRequired()
                .HasColumnName("unidade")
                .HasColumnType("varchar(2)");

            builder.HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.IdFornecedor);

            builder.Ignore(p => p.Errors);

            builder.ToTable("Produtos");
        }
    }
}
