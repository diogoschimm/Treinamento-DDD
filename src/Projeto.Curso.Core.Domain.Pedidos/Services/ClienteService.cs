using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services.PedidoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoService _pedidoService;

        public ClienteService(IClienteRepository clienteRepository, IPedidoService pedidoService)
        {
            this._clienteRepository = clienteRepository;
            this._pedidoService = pedidoService;
        }

        public Cliente Save(Cliente cliente)
        {
            if (!cliente.IsConsistente())
                return cliente;

            if (this.GetByApelido(cliente.Apelido) != null)
                cliente.AddError("Apelido já existe para outro Cliente");

            if (this.GetByDocumento(cliente.Documento.Numero) != null)
                cliente.AddError("Documento do Cliente já existe para outro Cliente");

            if (cliente.IsValid())
                this._clienteRepository.Save(cliente);

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            if (!cliente.IsConsistente())
                return cliente;

            var resultApelido = this.GetByApelido(cliente.Apelido);
            if (resultApelido != null && resultApelido.Id != cliente.Id)
                cliente.AddError("Apelido já existe para outro Cliente");

            var resultDocumento = this.GetByDocumento(cliente.Documento.Numero);
            if (resultDocumento != null && resultDocumento.Id != cliente.Id)
                cliente.AddError("Documento já existe para outro Cliente");

            if (cliente.IsValid())
                this._clienteRepository.Update(cliente);

            return cliente;
        }

        public Cliente Delete(Cliente cliente)
        { 
            if (this._pedidoService.Find(c => c.IdCliente == cliente.Id).Count() != 0)
                cliente.AddError("Existem pedidos para esse cliente");

            if (cliente.IsValid())
                this._clienteRepository.Delete(cliente);

            return cliente;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return this._clienteRepository.GetAll();
        }

        public Cliente GetById(int id)
        {
            return this._clienteRepository.GetById(id);
        }

        public Cliente GetByDocumento(string documento)
        {
            return this._clienteRepository.GetByDocumento(documento);
        }

        public Cliente GetByApelido(string apelido)
        {
            return this._clienteRepository.GetByApelido(apelido);
        }

        public void Dispose()
        {
            this._clienteRepository.Dispose();
            this._pedidoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
