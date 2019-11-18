using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string strIn)
        {
            if (strIn != null)
                return new string(strIn.Where(c => Char.IsDigit(c)).ToArray());

            return "";
        }

        public static string OnlyStrings(this string strIn)
        {
            if (strIn != null)
                return new string(strIn.Where(c => char.IsLetter(c)).ToArray());

            return "";
        }

        public static decimal ToDecimal(this string strIn, string masc)
        {
            if (strIn != null)
                return decimal.Parse(string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn));

            return 0;
        }

        public static string ToDocumento(this string strIn)
        {
            if (!string.IsNullOrEmpty(strIn))
            {
                if (strIn.Length == 11)
                    return strIn.ToCPF();

                else if (strIn.Length == 14)
                    return strIn.ToCNPJ();
            }
            return "";
        }

        public static string ToCPF(this string strIn)
        {
            if (!string.IsNullOrEmpty(strIn))
            {
                if (strIn.Length == 11)
                {
                    /// 123.456.789-01
                    return strIn.Substring(0,3) + ".";
                }
            }
            return "";
        }

        public static string ToCNPJ(this string strIn)
        {
            if (!string.IsNullOrEmpty(strIn))
            {
                if (strIn.Length == 14)
                {
                    /// 12.345.678/9012-34
                    return "";
                }
            }
            return "";
        }

    }
}
