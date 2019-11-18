using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Interfaces
{
   public interface IProdutoAppService: IDisposable
    {
        ProdutoViewModel Save(ProdutoViewModel produto);
        ProdutoViewModel Update(ProdutoViewModel produto);
        ProdutoViewModel Delete(ProdutoViewModel produto);

        IEnumerable<ProdutoViewModel> GetAll();
        ProdutoViewModel GetById(int id);
        ProdutoViewModel GetByName(string nome);
        ProdutoViewModel GetByApelido(string apelido);
    }
}
