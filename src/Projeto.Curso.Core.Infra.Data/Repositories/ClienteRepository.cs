using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(PedidosContext pedidosContext) : base(pedidosContext)
        {
        }

        public override IEnumerable<Cliente> GetAll()
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Clientes ORDER BY id DESC");

            return this.pedidosContext.Database.GetDbConnection().Query<Cliente>(str.ToString());
        }
        public override Cliente GetById(int id)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Clientes WHERE id = @id");

            return this.pedidosContext.Database.GetDbConnection().Query<Cliente>(str.ToString(), new { id }).FirstOrDefault();
        }

        public Cliente GetByApelido(string apelido)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Clientes WERE apelido = @apelido");

            return this.pedidosContext.Database.GetDbConnection().Query<Cliente>(str.ToString(), new { apelido }).FirstOrDefault();
        }

        public Cliente GetByDocumento(string documento)
        {
            var str = new StringBuilder();
            str.Append(@"SELECT * FROM Clientes WERE cpfCnpj = @documento");

            return this.pedidosContext.Database.GetDbConnection().Query<Cliente>(str.ToString(), new { documento }).FirstOrDefault();
        }

        private IEnumerable<Cliente> Query( string query,   SqlParameter[] parameters = null)
        {
            var lista = new List<Cliente>();

            return lista;
        }
        private void Fill(Cliente cliente, DbDataReader dr)
        {
            cliente.Id = (int) dr["id"];
            cliente.Apelido = dr["apelido"].ToString();
            cliente.Nome = dr["nome"].ToString();
            cliente.Documento.Numero = dr["cpfCnpj"].ToString();
            cliente.Endereco.CEP.Codigo = dr["cep"].ToString();
            cliente.Endereco.Logradouro = dr["endereco"].ToString();
            cliente.Endereco.Numero = dr["numeroEndereco"].ToString();
            cliente.Endereco.Bairro = dr["bairro"].ToString();
            cliente.Endereco.Cidade = dr["cidade"].ToString();
            cliente.Endereco.UF.Estado.Sigla = dr["uf"].ToString();
            cliente.Endereco.Complemento = dr["complemento"].ToString();
        }
    }
}
