using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            this.Errors = new List<string>();
        }
        public int Id { get; set; }
        public List<string> Errors { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }
    }
}
