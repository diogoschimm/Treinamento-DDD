using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Projeto.Curso.Core.Domain.Shared.ValuesObject
{
    public class Email
    {
        public string Endereco { get; set; }

        public bool Validar()
        {
            if (!string.IsNullOrEmpty(this.Endereco))
                return this.ValidarEmail(this.Endereco);

            return true;
        }

        private bool ValidarEmail(string email)
        { 
            return new Regex("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.*[a-zA-Z0-9-.]+$").IsMatch(email);
        }
    }
}
