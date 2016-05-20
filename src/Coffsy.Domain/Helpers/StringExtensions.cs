using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.Domain.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Verifica se a string é nula ou vazia
        /// </summary>
        /// <param name="value">Palavra para testar</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Trim().Length == 0;
        }

        /// <summary>
        /// Separar uma string em IList conforme o tamanho definido
        /// </summary>
        /// <param name="value">Palavra para ser separada</param>
        /// <param name="maximumSize">Tamanho máximo para separar a palavra</param>
        /// <returns></returns>
        public static string[] Split(this string value, int maximumSize)
        {
            if (value.IsNullOrEmpty())
            {
                return new string[0];
            }

            List<string> list = new List<string>();

            while (value.Length > 0)
            {
                int max = value.Length > maximumSize ? maximumSize : value.Length;
                list.Add(value.Substring(0, max));
                value = value.Remove(0, max);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Verifica se a palavra possui comprimento até o tamanho máximo permitido
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maximumSize"></param>
        /// <returns></returns>
        public static bool HasNotAllowedMaximumSize(this string value, int maximumSize)
        {
            return value.Length > maximumSize;
        }
    }
}