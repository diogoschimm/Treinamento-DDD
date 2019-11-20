using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Curso.Core.Application.Pedidos.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            this.Errors = new List<string>();
        }

        [Display(Name = "Id")]
        public int Id { get; set; }
        public List<string> Errors { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        [Display(Name ="E-mail")]
        public string Email { get; set; }
        public string CEP { get; set; }

        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Display(Name = "Nº do Endereço")]
        public string NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }

    }
}
