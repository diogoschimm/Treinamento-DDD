using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorViewModel Save(FornecedorViewModel fornecedor);
        FornecedorViewModel Update(FornecedorViewModel fornecedor);
        FornecedorViewModel Delete(FornecedorViewModel fornecedor);

        IEnumerable<FornecedorViewModel> GetAll();
        FornecedorViewModel GetById(int id);
        FornecedorViewModel GetByDocumento(string documento);
        FornecedorViewModel GetByApelido(string apelido);
    }
}
