using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services
{
    public interface IClienteService: IDisposable
    {
        Cliente Save(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente Delete(Cliente cliente);

        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        Cliente GetByDocumento(string documento);
        Cliente GetByApelido(string apelido);
    }
}
