using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaTexto
{
    class BuscaForcaBruta
    {
        public static List<int> forcaBruta(String p, String t, bool caseSensitive = true)
        {
            var resultados = new List<int>();
            int m = p.Length;
            int n = t.Length;
            if (n < m) return resultados;

            // Converte para minúsculo se não for case-sensitive
            string padraoComparacao = caseSensitive ? p : p.ToLower();
            string textoComparacao = caseSensitive ? t : t.ToLower();

            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    // Se não for coringa e não coincidir, quebra
                    if (padraoComparacao[j] != '?' && padraoComparacao[j] != textoComparacao[i + j])
                        break;
                }
                if (j == m)
                {
                    resultados.Add(i);
                }
            }
            return resultados;
        }
    }
}