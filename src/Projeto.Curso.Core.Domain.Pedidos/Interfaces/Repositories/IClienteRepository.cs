using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente GetByDocumento(string documento);
        Cliente GetByApelido(string apelido);
    }
}
