using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Context
{
    public class PedidosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new FornecedorMapping());
            modelBuilder.ApplyConfiguration(new ItemPedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
