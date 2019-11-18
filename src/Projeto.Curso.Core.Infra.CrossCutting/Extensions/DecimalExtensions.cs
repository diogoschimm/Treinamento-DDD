using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Projeto.Curso.Core.Infra.CrossCutting.Extensions
{
    public static class DecimalExtensions
    {
        public static string Formatar(this decimal decIn, string masc)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc,  decIn);
        }
    }
}
