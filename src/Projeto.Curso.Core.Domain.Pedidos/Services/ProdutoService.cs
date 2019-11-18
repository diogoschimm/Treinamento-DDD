using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IItemPedidoService _itemPedidoService;

        public ProdutoService(IProdutoRepository produtoRepository, IItemPedidoService itemPedidoService)
        {
            this._produtoRepository = produtoRepository;
            this._itemPedidoService = itemPedidoService;
        }

        public Produto Save(Produto produto)
        {
            if (!produto.IsConsistente())
                return produto;

            if (this.GetByName(produto.Nome) != null)
                produto.AddError("Já exite um produto com este Nome");

            if (this.GetByApelido(produto.Apelido) != null)
                produto.AddError("Já existe um produto com este Apelido");

            if (produto.IsValid())
                this._produtoRepository.Save(produto);

            return produto;
        }
        public Produto Update(Produto produto)
        {
            if (!produto.IsConsistente())
                return produto;

            var resultNome = this.GetByName(produto.Nome);
            if (resultNome != null && resultNome.Id != produto.Id)
                produto.AddError("Já existe um produto com este Nome");

            var resultApelido = this.GetByApelido(produto.Apelido);
            if (resultApelido != null && resultApelido.Id != produto.Id)
                produto.AddError("Já existe um produto com este Apelido");

            if (produto.IsValid())
                this._produtoRepository.Update(produto);

            return produto;
        }
        public Produto Delete(Produto produto)
        {
            if (this._itemPedidoService.Find(x => x.IdProduto == produto.Id).Count() != 0)
                produto.AddError("Existem Pedidos com este Produto");

            if (produto.IsValid())
                this._produtoRepository.Delete(produto);

            return produto;
        }

        public IEnumerable<Produto> GetAll()
        {
            return this._produtoRepository.GetAll();
        }
        public Produto GetById(int id)
        {
            return this._produtoRepository.GetById(id);
        }
        public Produto GetByName(string nome)
        {
            return this._produtoRepository.GetByName(nome);
        }
        public Produto GetByApelido(string apelido)
        {
            return this._produtoRepository.GetByApelido(apelido);
        }
        public IEnumerable<Produto> Find(Expression<Func<Produto, bool>> expression)
        {
            return this._produtoRepository.Find(expression);
        }

        public void Dispose()
        {
            this._produtoRepository.Dispose();
        }

    }
}
