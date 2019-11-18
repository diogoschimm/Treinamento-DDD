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
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(PedidosContext pedidosContext) : base(pedidosContext)
        {
        }

        public override IEnumerable<Fornecedor> GetAll()
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Fornecedores ORDER BY id DESC");

            return this.pedidosContext.Database.GetDbConnection().Query<Fornecedor>(str.ToString());
        }
        public override Fornecedor GetById(int id)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Fornecedores WHERE id = @id");

            return this.pedidosContext.Database.GetDbConnection().Query<Fornecedor>(str.ToString(), new { id }).FirstOrDefault();
        }

        public Fornecedor GetByApelido(string apelido)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Fornecedores WHERE apelido = @apelido");

            return this.pedidosContext.Database.GetDbConnection().Query<Fornecedor>(str.ToString(), new { apelido }).FirstOrDefault();
        }

        public Fornecedor GetByDocumento(string documento)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Fornecedores WHERE cpfCnpj = @documento");

            return this.pedidosContext.Database.GetDbConnection().Query<Fornecedor>(str.ToString(), new { documento }).FirstOrDefault();
        }
    }
}
