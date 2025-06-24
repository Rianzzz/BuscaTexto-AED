using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaTexto
{
    class BuscaBoyerMoore
    {
        static int[] skip = new int[256];

        public static void initSkip(String p)
        {
            int j, m = p.Length;
            for (j = 0; j < 256; j++)
                skip[j] = m;
            for (j = 0; j < m; j++)
                skip[p[j]] = m - j - 1;
        }

        public static List<int> BMSearchAll(String p, String t, bool caseSensitive = true)
        {
            var resultados = new List<int>();

            // Converte para minúsculo se não for case-sensitive
            string padraoComparacao = caseSensitive ? p : p.ToLower();
            string textoComparacao = caseSensitive ? t : t.ToLower();

            int m = padraoComparacao.Length;
            int n = textoComparacao.Length;

            if (n < m) return resultados;

            initSkip(padraoComparacao);

            int i = m - 1;
            while (i < n)
            {
                int j = m - 1;
                int k = i;

                while (j >= 0 && textoComparacao[k] == padraoComparacao[j])
                {
                    k--;
                    j--;
                }

                if (j < 0)
                {
                    resultados.Add(k + 1);
                    i += m; // Avança para próxima posição
                }
                else
                {
                    int a = skip[textoComparacao[i]];
                    i += Math.Max(m - j, a);
                }
            }

            return resultados;
        }

        public static int BMSearch(String p, String t)
        {
            int i, j, a, m = p.Length, n = t.Length;
            i = m - 1;
            j = m - 1;
            initSkip(p);
            while (j >= 0)
            {
                while (t[i] != p[j])
                {
                    a = skip[t[i]];
                    i += (m - j > a) ? (m - j) : a;
                    if (i >= n)
                        return -1;
                    j = m - 1;
                }
                i--;
                j--;
            }
            return i + 1;
        }
    }
}