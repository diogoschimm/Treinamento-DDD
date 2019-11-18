using AutoMapper;
using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using Projeto.Curso.Core.Application.Pedidos.ViewModels.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ConvertUsing((origem, destino) =>
                {
                    //destino.Id = origem.Id;
                    //destino.Apelido = origem.Apelido;
                    //destino.Nome = origem.Nome;

                    destino.Documento = origem.Documento.Numero.ToDocumento();
                    destino.Email = origem.Email.Endereco;
                    destino.CEP = origem.Endereco.CEP.Codigo;
                    destino.Logradouro = origem.Endereco.Logradouro;
                    destino.NumeroEndereco = origem.Endereco.Numero;
                    destino.Bairro = origem.Endereco.Bairro;
                    destino.Cidade = origem.Endereco.Cidade;
                    destino.UF = origem.Endereco.UF.Estado.Sigla;

                    return destino;
                });

                //.ForMember(to => to.Documento, opt => opt.MapFrom(from => from.Documento.Numero.ToDocumento()))
                //.ForMember(to => to.Email, opt => opt.MapFrom(from => from.Email.Endereco))
                //.ForMember(to => to.CEP, opt => opt.MapFrom(from => from.Endereco.CEP.Codigo))
                //.ForMember(to => to.Logradouro, opt => opt.MapFrom(from => from.Endereco.Logradouro))
                //.ForMember(to => to.NumeroEndereco, opt => opt.MapFrom(from => from.Endereco.Numero))
                //.ForMember(to => to.Bairro, opt => opt.MapFrom(from => from.Endereco.Bairro))
                //.ForMember(to => to.Cidade, opt => opt.MapFrom(from => from.Endereco.Cidade))
                //.ForMember(to => to.UF, opt => opt.MapFrom(from => from.Endereco.UF.Estado.Sigla));

            CreateMap<Fornecedor, FornecedorViewModel>()
                .ConvertUsing((origem, destino) =>
                {
                    //destino.Id = origem.Id;
                    //destino.Apelido = origem.Apelido;
                    //destino.Nome = origem.Nome;

                    destino.Documento = origem.Documento.Numero.ToDocumento();
                    destino.Email = origem.Email.Endereco;
                    destino.CEP = origem.Endereco.CEP.Codigo;
                    destino.Logradouro = origem.Endereco.Logradouro;
                    destino.NumeroEndereco = origem.Endereco.Numero;
                    destino.Bairro = origem.Endereco.Bairro;
                    destino.Cidade = origem.Endereco.Cidade;
                    destino.UF = origem.Endereco.UF.Estado.Sigla;

                    return destino;
                });
                //.ForMember(to => to.Documento, opt => opt.MapFrom(from => from.Documento.Numero.ToDocumento()))
                //.ForMember(to => to.Email, opt => opt.MapFrom(from => from.Email.Endereco))
                //.ForMember(to => to.CEP, opt => opt.MapFrom(from => from.Endereco.CEP.Codigo))
                //.ForMember(to => to.Logradouro, opt => opt.MapFrom(from => from.Endereco.Logradouro))
                //.ForMember(to => to.NumeroEndereco, opt => opt.MapFrom(from => from.Endereco.Numero))
                //.ForMember(to => to.Bairro, opt => opt.MapFrom(from => from.Endereco.Bairro))
                //.ForMember(to => to.Cidade, opt => opt.MapFrom(from => from.Endereco.Cidade))
                //.ForMember(to => to.UF, opt => opt.MapFrom(from => from.Endereco.UF.Estado.Sigla));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.Formatar("{0:#,###,###0.00}")));

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatar("{0:d}")))
                .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatar("{0:d}")));
            
            CreateMap<ItemPedido, ItemPedidoViewModel>();

        }
    }
}
