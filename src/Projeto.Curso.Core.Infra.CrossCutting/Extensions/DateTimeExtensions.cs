using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Projeto.Curso.Core.Infra.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Formatar(this DateTime dateIn, string masc)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, dateIn);
        }

        public static string Formatar(this DateTime? dateIn, string masc)
        {
            if (dateIn.HasValue)
                return dateIn.Value.Formatar(masc);

            return "";
        }
    }
}
