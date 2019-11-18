using Projeto.Curso.Core.Domain.Pedidos.Entities;
using Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Fornecedor GetByDocumento(string documento);
        Fornecedor GetByApelido(string apelido);
    }
}
