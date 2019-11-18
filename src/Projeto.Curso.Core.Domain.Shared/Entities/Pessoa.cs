using Projeto.Curso.Core.Domain.Shared.ValuesObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Curso.Core.Domain.Shared.Entities
{
    public abstract class Pessoa : EntidadeBase
    {
        public Pessoa()
        {
            this.Documento = new Documento();
            this.Email = new Email();
            this.Endereco = new Endereco();
        }

        public string Apelido { get; set; }
        public string Nome { get; set; }
        public Documento Documento { get; set; }
        public Email Email { get; set; }
        public Endereco Endereco { get; set; }
         
        protected  void ValidarApelido(int tamanho)
        {
            if (string.IsNullOrEmpty(this.Apelido))
                this.AddError("Apelido não pode ser em Branco");

            if (this.Apelido != null && this.Apelido.Length > tamanho)
                this.AddError($"Apelido não pode ter mais de {tamanho} Caracteres");
        }
        protected void ValidarNome(int tamanho)
        {
            if (string.IsNullOrEmpty(this.Nome))
                this.AddError("Nome do Cliente não pode ser em Branco");

            if (this.Nome != null && this.Nome.Length > tamanho)
                this.AddError($"Nome do Cliente não pode ser maior que {tamanho} Caracteres");
        }
        protected void ValidarDocumento()
        {
            if (string.IsNullOrEmpty(this.Documento.Numero))
                this.AddError("CPF ou CNPJ do Cliente deve ser preenchido");

            if (!this.Documento.Validar())
                this.AddError("CPF ou CNPJ Inválido");
        }
        protected void ValidarEmail(int tamanho)
        {
            if (!string.IsNullOrEmpty(this.Email.Endereco))
            {
                if (!this.Email.Validar())
                    this.AddError("E-mail inválido");

                if (this.Email.Endereco.Length > tamanho)
                    this.AddError($"E-mail não pode ser maior que {tamanho} Caracteres");
            }
        }
        protected void ValidarEndereco()
        {
            if (string.IsNullOrEmpty(this.Endereco.CEP.Codigo))
                this.AddError("CEP não pode ser em Branco");

            if (!this.Endereco.CEP.Validar())
                this.AddError("CEP Inválido");

            if (string.IsNullOrEmpty(this.Endereco.Logradouro))
                this.AddError("Logradouro não pode ser em Branco");

            if (this.Endereco.Logradouro != null && this.Endereco.Logradouro.Length > 100)
                this.AddError("Logradouro não pode ter mais de 100 Caracteres");

            if (string.IsNullOrEmpty(this.Endereco.Numero))
                this.AddError("Nº do Endereço não pode ser em Branco");

            if (this.Endereco.Numero != null && this.Endereco.Numero.Length > 20)
                this.AddError("Nº do Endereço não pode ter mais de 20 Caracteres");

            if (!string.IsNullOrEmpty(this.Endereco.Bairro))
            {
                if (this.Endereco.Bairro.Length > 60)
                    this.AddError("Bairro não pode ter mais de 60 Caracteres");
            }

            if (string.IsNullOrEmpty(this.Endereco.Cidade))
                this.AddError("Cidade não pode ser em Branco");

            if (this.Endereco.Cidade != null && this.Endereco.Cidade.Length > 100)
                this.AddError("Cidade não pode ter mais de 100 Caracteres");

            if (string.IsNullOrEmpty(this.Endereco.UF.Estado.Sigla))
                this.AddError("UF não pode ser em Branco");

            if (!this.Endereco.UF.Validar())
                this.AddError("UF Inválida");
        }
    }
}
