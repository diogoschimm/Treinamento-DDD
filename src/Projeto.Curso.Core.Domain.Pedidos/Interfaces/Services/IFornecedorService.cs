using Projeto.Curso.Core.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Pedidos.Interfaces.Services
{
    public interface IFornecedorService: IDisposable
    {
        Fornecedor Save(Fornecedor fornecedor);
        Fornecedor Update(Fornecedor fornecedor);
        Fornecedor Delete(Fornecedor fornecedor);

        IEnumerable<Fornecedor> GetAll();
        Fornecedor GetById(int id);
        Fornecedor GetByDocumento(string documento);
        Fornecedor GetByApelido(string apelido);
    }
}
