using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Domain.Shared.ValuesObject
{
    public class UF
    {
        public UF()
        {
            this.Estado = new Estado();
        }

        public Estado Estado { get; set; }

        public bool Validar()
        {
            if (!string.IsNullOrEmpty(this.Estado.Sigla))
                return ValidarUF();

            return true;
        }

        private bool ValidarUF()
        {
            if (this.Estado.Sigla.OnlyNumbers().Length != 0)
                return false;

            if (this.Estado.Sigla.OnlyStrings().Length != 2)
                return false;

            if (!this.ListarEstados().Where(e => e.Sigla == this.Estado.Sigla).Any())
                return false;

            return false;
        }

        public List<Estado> ListarEstados()
        {
            return new List<Estado>()
            {
                new Estado() {Sigla = "AC"},
                new Estado() {Sigla = "AL"},
                new Estado() {Sigla = "AP"},
                new Estado() {Sigla = "AM"},
                new Estado() {Sigla = "BA"},
                new Estado() {Sigla = "CE"},
                new Estado() {Sigla = "DF"},
                new Estado() {Sigla = "ES"},
                new Estado() {Sigla = "GO"},
                new Estado() {Sigla = "MA"},
                new Estado() {Sigla = "MG"},
                new Estado() {Sigla = "MT"},
                new Estado() {Sigla = "MS"},
                new Estado() {Sigla = "PA"},
                new Estado() {Sigla = "PB"},
                new Estado() {Sigla = "PI"},
                new Estado() {Sigla = "PR"},
                new Estado() {Sigla = "RJ"},
                new Estado() {Sigla = "RN"},
                new Estado() {Sigla = "RS"},
                new Estado() {Sigla = "RO"},
                new Estado() {Sigla = "RR"},
                new Estado() {Sigla = "SC"},
                new Estado() {Sigla = "SE"},
                new Estado() {Sigla = "SP"},
                new Estado() {Sigla = "TO"}
            };
        }
    }
}
