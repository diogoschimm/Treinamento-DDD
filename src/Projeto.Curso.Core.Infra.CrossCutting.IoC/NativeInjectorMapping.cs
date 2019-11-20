using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Curso.Core.Application.Pedidos.AutoMapper;
using Projeto.Curso.Core.Application.Pedidos.Interfaces;
using Projeto.Curso.Core.Application.Pedidos.Interfaces.PedidoAggregate;
using Projeto.Curso.Core.Application.Pedidos.Services;
using Projeto.Curso.Core.Application.Pedidos.Services.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Aggregates;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Services;
using Projeto.Curso.Core.Domain.Pedidos.Services.PedidoAggregate;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Repositories;
using Projeto.Curso.Core.Infra.Data.Repositories.Aggregates;
using System;

namespace Projeto.Curso.Core.Infra.CrossCutting.IoC
{
    public class NativeInjectorMapping
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterServicesApplication(services);
            RegisterServicesDomain(services);
            RegisterServicesRepository(services);

            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());
            services.AddScoped<PedidosContext>();
        }

        private static void RegisterServicesApplication(IServiceCollection services)
        {
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IFornecedorAppService, FornecedorAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();
            services.AddScoped<IItemPedidoAppService, ItemPedidoAppService>();
        }

        private static void RegisterServicesDomain(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IItemPedidoService, ItemPedidoService>();
        }

        private static void RegisterServicesRepository(IServiceCollection services)
        { 
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }

    }
}
