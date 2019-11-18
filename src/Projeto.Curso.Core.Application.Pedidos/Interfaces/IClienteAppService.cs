using Projeto.Curso.Core.Application.Pedidos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.Interfaces
{
    public interface IClienteAppService: IDisposable
    {
        ClienteViewModel Save(ClienteViewModel cliente);
        ClienteViewModel Update(ClienteViewModel cliente);
        ClienteViewModel Delete(ClienteViewModel cliente);

        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(int id);
        ClienteViewModel GetByDocumento(string documento);
        ClienteViewModel GetByApelido(string apelido);
    }
}
