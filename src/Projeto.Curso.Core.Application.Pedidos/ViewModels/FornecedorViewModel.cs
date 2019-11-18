using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.ViewModels
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            this.Errors = new List<string>();
        }

        public int Id { get; set; }
        public List<string> Errors { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
    }
}
