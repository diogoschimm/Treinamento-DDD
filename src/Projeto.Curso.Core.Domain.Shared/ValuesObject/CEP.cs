using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Shared.ValuesObject
{
    public class CEP
    {
        public string Codigo { get; set; }

        public bool Validar()
        {
            if (!string.IsNullOrEmpty(this.Codigo))
                return ValidarCEP();

            return true;
        }
        private bool ValidarCEP()
        {
            if (this.Codigo.OnlyStrings().Length != 0)
                return false;

            if (this.Codigo.OnlyNumbers().Length != 8)
                return false;

            return true;
        }
    }
}
