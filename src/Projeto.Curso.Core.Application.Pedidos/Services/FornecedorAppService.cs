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
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorAppService(IFornecedorService fornecedorService, IMapper mapper)
        {
            this._fornecedorService = fornecedorService;
            this._mapper = mapper;
        }

        public FornecedorViewModel Save(FornecedorViewModel fornecedor)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.Save(this._mapper.Map<Fornecedor>(fornecedor)));
        }
        public FornecedorViewModel Update(FornecedorViewModel fornecedor)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.Update(this._mapper.Map<Fornecedor>(fornecedor)));
        }
        public FornecedorViewModel Delete(FornecedorViewModel fornecedor)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.Delete(this._mapper.Map<Fornecedor>(fornecedor)));
        }

        public IEnumerable<FornecedorViewModel> GetAll()
        {
            return this._mapper.Map<IEnumerable<FornecedorViewModel>>(this._fornecedorService.GetAll());
        }
        public FornecedorViewModel GetById(int id)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.GetById(id));
        }
        public FornecedorViewModel GetByApelido(string apelido)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.GetByApelido(apelido));
        }
        public FornecedorViewModel GetByDocumento(string documento)
        {
            return this._mapper.Map<FornecedorViewModel>(this._fornecedorService.GetByDocumento(documento));
        }

        public void Dispose()
        {
            this._fornecedorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
