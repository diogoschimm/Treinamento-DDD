using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IProdutoService produtoService)
        {
            this._fornecedorRepository = fornecedorRepository;
            this._produtoService = produtoService;
        }

        public Fornecedor Save(Fornecedor fornecedor)
        {
            if (!fornecedor.IsConsistente())
                return fornecedor;

            if (this.GetByApelido(fornecedor.Apelido) != null)
                fornecedor.AddError("Apelido já existe para outro Fornecedor");

            if (this.GetByDocumento(fornecedor.Documento.Numero) != null)
                fornecedor.AddError("Documento do Fornecedor já existe para outro Fornecedor");

            if (fornecedor.IsValid())
                this._fornecedorRepository.Save(fornecedor);

            return fornecedor;
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            if (!fornecedor.IsConsistente())
                return fornecedor;

            var resultApelido = this.GetByApelido(fornecedor.Apelido);
            if (resultApelido != null && resultApelido.Id != fornecedor.Id)
                fornecedor.AddError("Apelido já existe para outro Fornecedor");

            var resultDocumento = this.GetByDocumento(fornecedor.Documento.Numero);
            if (resultDocumento != null && resultDocumento.Id != fornecedor.Id)
                fornecedor.AddError("Documento do Fornecedor já existe para outro Fornecedor");

            if (fornecedor.IsValid())
                this._fornecedorRepository.Update(fornecedor);

            return fornecedor;
        }
        public Fornecedor Delete(Fornecedor fornecedor)
        {
            if (this._produtoService.Find(p => p.IdFornecedor == fornecedor.Id).Count() != 0)
                fornecedor.AddError("Existem produtos cadastrados para este fornecedor");

            if (fornecedor.IsValid())
                this._fornecedorRepository.Delete(fornecedor);

            return fornecedor;
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return this._fornecedorRepository.GetAll();
        }
        public Fornecedor GetById(int id)
        {
            return this._fornecedorRepository.GetById(id);
        }
        public Fornecedor GetByDocumento(string documento)
        {
            return this._fornecedorRepository.GetByDocumento(documento);
        }
        public Fornecedor GetByApelido(string apelido)
        {
            return this._fornecedorRepository.GetByApelido(apelido);
        }

        public void Dispose()
        {
            this._fornecedorRepository.Dispose();
        }
    }
}
