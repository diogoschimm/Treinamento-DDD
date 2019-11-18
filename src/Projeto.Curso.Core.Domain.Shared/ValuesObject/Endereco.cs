using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Shared.ValuesObject
{
    public class Endereco
    {
        public Endereco()
        {
            this.CEP = new CEP();
            this.UF = new UF();
        }

        public CEP CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public UF UF { get; set; } 
        public string Complemento { get; set; }
    }
}
