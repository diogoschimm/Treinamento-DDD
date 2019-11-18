using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Apelido)
                .HasColumnType("varchar(20)"); 

            builder.Property(f => f.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.OwnsOne(f => f.Documento, doc =>
            {
                doc.Property(d => d.Numero)
                    .IsRequired()
                    .HasColumnName("cpfCnpj")
                    .HasColumnType("varchar(14)");

                doc.HasIndex(d => d.Numero).IsUnique();
            });

            builder.OwnsOne(f => f.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");
            });
            builder.OwnsOne(f => f.Endereco).OwnsOne(c => c.CEP, cep =>
            {
                cep.Property(c => c.Codigo)
                   .IsRequired()
                   .HasColumnName("cep")
                   .HasColumnType("varchar(9)");
            });

            builder.OwnsOne(f => f.Endereco, endereco =>
            {
                endereco.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasColumnType("varchar(100)");

                endereco.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numeroEndereco")
                    .HasColumnType("varchar(20)");

                endereco.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasColumnType("varchar(60)");

                endereco.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasColumnType("varchar(100)");

                endereco.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasColumnType("varchar(100)");
            });

            builder.OwnsOne(f => f.Endereco).OwnsOne(e => e.UF).OwnsOne(e => e.Estado, estado =>
            {
                estado.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasColumnType("varchar(2)");
            });

            builder.Ignore(f => f.Errors);

            builder.ToTable("Fornecedores");
        }
    }
}
