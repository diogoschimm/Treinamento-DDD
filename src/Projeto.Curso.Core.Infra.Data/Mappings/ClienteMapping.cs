using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.HasIndex(c => c.Apelido).IsUnique();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.OwnsOne(c => c.Documento, doc =>
            {
                doc.Property(d => d.Numero)
                    .IsRequired()
                    .HasColumnName("cpfCnpj")
                    .HasColumnType("varchar(14)");

                doc.HasIndex(d => d.Numero).IsUnique();
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");
            });
            builder.OwnsOne(c => c.Endereco).OwnsOne(c => c.CEP, cep =>
            {
                 cep.Property(c => c.Codigo)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasColumnType("varchar(9)");
             });

            builder.OwnsOne(c => c.Endereco, endereco =>
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

            builder.OwnsOne(e => e.Endereco).OwnsOne(e => e.UF).OwnsOne(e => e.Estado, estado =>
            {
                estado.Property(e => e.Sigla)
                    .IsRequired()
                    .HasColumnName("uf")
                    .HasColumnType("varchar(2)");
            });

            builder.Ignore(c => c.Errors);

            builder.ToTable("Clientes");
        }
    }
}
