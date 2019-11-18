using AutoMapper;
using Projeto.Curso.Core.Application.Pedidos.Interfaces;
using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteService clienteService, IMapper mapper)
        {
            this._clienteService = clienteService;
            this._mapper = mapper;
        }

        public ClienteViewModel Save(ClienteViewModel cliente)
        { 
            return this._mapper.Map<ClienteViewModel>(this._clienteService.Save(this._mapper.Map<Cliente>(cliente)));
        }
        public ClienteViewModel Update(ClienteViewModel cliente)
        {
            return this._mapper.Map<ClienteViewModel>(this._clienteService.Update(this._mapper.Map<Cliente>(cliente)));
        }
        public ClienteViewModel Delete(ClienteViewModel cliente)
        {
            return this._mapper.Map<ClienteViewModel>(this._clienteService.Delete(this._mapper.Map<Cliente>(cliente)));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return this._mapper.Map<IEnumerable<ClienteViewModel>>(this._clienteService.GetAll());
        }
        public ClienteViewModel GetById(int id)
        {
            return this._mapper.Map<ClienteViewModel>(this._clienteService.GetById(id));
        }
        public ClienteViewModel GetByApelido(string apelido)
        {
            return this._mapper.Map<ClienteViewModel>(this._clienteService.GetByApelido(apelido));
        }
        public ClienteViewModel GetByDocumento(string documento)
        {
            return this._mapper.Map<ClienteViewModel>(this._clienteService.GetByDocumento(documento.OnlyNumbers()));
        }

        public void Dispose()
        {
            this._clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
