using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Shared.Entities
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            this.Errors = new List<string>();
        }

        public int Id { get; set; }
        public List<string> Errors { get; set; }

        public void AddError(string erro) => this.Errors.Add(erro);

        public bool IsInvalid() => this.Errors.Count > 0;
        public bool IsValid() => this.Errors.Count == 0;

        public abstract bool IsConsistente();

    }
}
