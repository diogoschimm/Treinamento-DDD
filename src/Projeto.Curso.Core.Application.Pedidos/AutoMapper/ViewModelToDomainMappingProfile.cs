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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                .ForPath(to => to.Documento.Numero.OnlyNumbers(), opt => opt.MapFrom(from => from.Documento))
                .ForPath(to => to.Email.Endereco, opt => opt.MapFrom(from => from.Email))
                .ForPath(to => to.Endereco.CEP.Codigo.OnlyNumbers(), opt => opt.MapFrom(from => from.CEP))
                .ForPath(to => to.Endereco.Logradouro, opt => opt.MapFrom(from => from.Logradouro))
                .ForPath(to => to.Endereco.Numero, opt => opt.MapFrom(from => from.NumeroEndereco))
                .ForPath(to => to.Endereco.Bairro, opt => opt.MapFrom(from => from.Bairro))
                .ForPath(to => to.Endereco.Cidade, opt => opt.MapFrom(from => from.Cidade))
                .ForPath(to => to.Endereco.UF.Estado.Sigla, opt => opt.MapFrom(from => from.UF));

            CreateMap<FornecedorViewModel, Fornecedor>()
                .ForPath(to => to.Documento.Numero.OnlyNumbers(), opt => opt.MapFrom(from => from.Documento))
                .ForPath(to => to.Email.Endereco, opt => opt.MapFrom(from => from.Email))
                .ForPath(to => to.Endereco.CEP.Codigo.OnlyNumbers(), opt => opt.MapFrom(from => from.CEP))
                .ForPath(to => to.Endereco.Logradouro, opt => opt.MapFrom(from => from.Logradouro))
                .ForPath(to => to.Endereco.Numero, opt => opt.MapFrom(from => from.NumeroEndereco))
                .ForPath(to => to.Endereco.Bairro, opt => opt.MapFrom(from => from.Bairro))
                .ForPath(to => to.Endereco.Cidade, opt => opt.MapFrom(from => from.Cidade))
                .ForPath(to => to.Endereco.UF.Estado.Sigla, opt => opt.MapFrom(from => from.UF));

            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.ToDecimal("{0:#,###,###0.00}")));

            CreateMap<PedidoViewModel, Pedido>()
                .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataPedido)))
                .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataEntrega)));

            CreateMap<ItemPedidoViewModel, ItemPedido>();

        }
    }
}
