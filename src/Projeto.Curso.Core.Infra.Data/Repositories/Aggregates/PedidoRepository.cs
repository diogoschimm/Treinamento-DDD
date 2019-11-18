using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedidos.Aggregates.PedidoAggregate;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Aggregates;
using Projeto.Curso.Core.Infra.Data.Context;
using Projeto.Curso.Core.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repositories.Aggregates
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(PedidosContext pedidosContext) : base(pedidosContext)
        {
        }

        public override IEnumerable<Pedido> GetAll()
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Pedidos P 
                          JOIN Clientes C ON P.idCliente = C.id");

            var pedidos = this.pedidosContext.Database
                            .GetDbConnection()
                            .Query<Pedido, Cliente, Pedido>(str.ToString(), (P, C) => {
                                P.Cliente = C;
                                return P;
                             });

            foreach (var item in pedidos)
            {
                item.ItensPedido = this.GetItensPedido(item.Id).ToList(); 
            }
            return pedidos;
        }
        public override Pedido GetById(int id)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Pedidos P 
                          JOIN Clientes C ON P.idCliente = C.id
                          WHERE P.id = @id");

            var pedidos = this.pedidosContext.Database
                            .GetDbConnection()
                            .Query<Pedido, Cliente, Pedido>(str.ToString(), (p, c) => {
                                p.Cliente = c;
                                return p;
                            }, new { id });

            foreach (var item in pedidos)
            {
                item.ItensPedido = this.GetItensPedido(item.Id).ToList(); 
            }
            return pedidos.FirstOrDefault();
        }

        public void AddItemPedido(ItemPedido itemPedido)
        {
            this.pedidosContext.ItensPedido.Add(itemPedido);
        }
        public void UpdateItemPedido(ItemPedido itemPedido)
        {
            this.pedidosContext.ItensPedido.Update(itemPedido);
        }
        public void DeleteItemPedido(ItemPedido itemPedido)
        {
            this.pedidosContext.ItensPedido.Remove(itemPedido);
        }

        public IEnumerable<ItemPedido> GetItensPedido(int idPedido)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Pedidos p
                          JOIN Clientes c ON p.idCliente = c.Id
                          JOIN ItensPedido ip on p.Id = ip.idPedido
                          JOIN Produtos pd on ip.idProduto = pd.Id
                          JOIN Fornecedores f on pd.IdFornecedor = f.Id
                          WHERE ip.idPedido = @idPedido 
                          ");
             
            var itensPedido = this.pedidosContext.Database
                                .GetDbConnection()
                                .Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(str.ToString(), (p, c, ip, pd, f) => {
                                    p.Cliente = c;
                                    ip.Pedido = p;
                                    pd.Fornecedor = f;
                                    ip.Produto = pd;
                                    return ip;
                                }, new { idPedido });

            return itensPedido;
        }
        public ItemPedido GetItemPedidoById(int id)
        {
            var str = new StringBuilder();
            str.Append(@" SELECT * FROM Pedidos p
                          JOIN Clientes c ON p.idCliente = c.Id
                          JOIN ItensPedido ip on p.Id = ip.idPedido
                          JOIN Produtos pd on ip.idProduto = pd.Id
                          JOIN Fornecedores f on pd.IdFornecedor = f.Id
                          WHERE ip.id = @id 
                          ");

            var itensPedido = this.pedidosContext.Database
                                .GetDbConnection()
                                .Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(str.ToString(), 
                                    (p, c, ip, pd, f) => {
                                        p.Cliente = c;
                                        ip.Pedido = p;
                                        pd.Fornecedor = f;
                                        ip.Produto = pd;
                                        return ip;
                                    }, new { id });

            return itensPedido.FirstOrDefault();
        }

        public IEnumerable<ItemPedido> FindItemPedido(Expression<Func<ItemPedido, bool>> expression)
        {
            return this.pedidosContext.ItensPedido.Where(expression);
        }
    }
}
