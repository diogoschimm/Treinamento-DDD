using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PedidosContext pedidosContext) : base(pedidosContext)
        {
        }

        public override IEnumerable<Produto> GetAll()
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Produtos P
                          JOIN Fornecedores F ON P.idFornecedor = F.id
                          ORDER BY P.id DESC ");

            return this.pedidosContext.Database
                    .GetDbConnection()
                    .Query<Produto, Fornecedor, Produto>(str.ToString(), (P, F) => { P.Fornecedor = F; return P; });
        }

        public override Produto GetById(int id)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Produtos P
                          JOIN Fornecedores F ON P.idFornecedor = F.id
                          WHERE P.id = @id ");

            return this.pedidosContext.Database
                    .GetDbConnection()
                    .Query<Produto, Fornecedor, Produto>(str.ToString(), (P, F) => { P.Fornecedor = F; return P; }, new { id })
                    .FirstOrDefault();
        }

        public Produto GetByApelido(string apelido)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Produtos P
                          JOIN Fornecedores F ON P.idFornecedor = F.id
                          WHERE P.Apelido = @apelido ");

            return this.pedidosContext.Database
                    .GetDbConnection()
                    .Query<Produto, Fornecedor, Produto>(str.ToString(), (P, F) => { P.Fornecedor = F; return P; }, new { apelido })
                    .FirstOrDefault();
        }

        public Produto GetByName(string nome)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Produtos P
                          JOIN Fornecedores F ON P.idFornecedor = F.id
                          WHERE P.Nome = @nome ");

            return this.pedidosContext.Database
                    .GetDbConnection()
                    .Query<Produto, Fornecedor, Produto>(str.ToString(), (P, F) => { P.Fornecedor = F; return P; }, new { nome })
                    .FirstOrDefault();
        }
    }
}
