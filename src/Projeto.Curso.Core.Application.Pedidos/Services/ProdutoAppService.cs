using AutoMapper;
using Projeto.Curso.Core.Application.Pedidos.Interfaces;
using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IMapper mapper)
        {
            this._produtoService = produtoService;
            this._mapper = mapper;
        }

        public ProdutoViewModel Save(ProdutoViewModel produto)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.Save(this._mapper.Map<Produto>(produto)));
        }
        public ProdutoViewModel Update(ProdutoViewModel produto)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.Update(this._mapper.Map<Produto>(produto)));
        }
        public ProdutoViewModel Delete(ProdutoViewModel produto)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.Delete(this._mapper.Map<Produto>(produto)));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return this._mapper.Map<IEnumerable<ProdutoViewModel>>(this._produtoService.GetAll());
        }
        public ProdutoViewModel GetById(int id)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.GetById(id));
        }
        public ProdutoViewModel GetByApelido(string apelido)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.GetByApelido(apelido));
        }
        public ProdutoViewModel GetByName(string nome)
        {
            return this._mapper.Map<ProdutoViewModel>(this._produtoService.GetByName(nome));
        }

        public void Dispose()
        {
            this._produtoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
