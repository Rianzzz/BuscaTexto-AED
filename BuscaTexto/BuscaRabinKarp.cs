using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaTexto
{
    class BuscaRabinKarp
    {
        const long q = 10014521L;
        const int d = 128;

        public static List<int> RKSearchAll(String p, String t, bool caseSensitive = true)
        {
            var resultados = new List<int>();

            // Converte para minúsculo se não for case-sensitive
            string padraoComparacao = caseSensitive ? p : p.ToLower();
            string textoComparacao = caseSensitive ? t : t.ToLower();

            int m = padraoComparacao.Length;
            int n = textoComparacao.Length;

            if (n < m) return resultados;

            long dm = 1, h1 = 0, h2 = 0;
            int i;

            for (i = 1; i < m; i++)
                dm = (d * dm) % q;

            for (i = 0; i < m; i++)
            {
                h1 = (h1 * d + padraoComparacao[i]) % q;
                h2 = (h2 * d + textoComparacao[i]) % q;
            }

            for (i = 0; i <= n - m; i++)
            {
                if (h1 == h2)
                {
                    // Verifica se realmente coincide
                    bool coincide = true;
                    for (int k = 0; k < m; k++)
                    {
                        if (padraoComparacao[k] != textoComparacao[i + k])
                        {
                            coincide = false;
                            break;
                        }
                    }
                    if (coincide)
                    {
                        resultados.Add(i);
                    }
                }

                if (i < n - m)
                {
                    h2 = (h2 + d * q - textoComparacao[i] * dm) % q;
                    h2 = (h2 * d + textoComparacao[i + m]) % q;
                }
            }

            return resultados;
        }

        public static int RKSearch(String p, String t)
        {
            long dm = 1, h1 = 0, h2 = 0;
            int i;
            int m = p.Length;
            int n = t.Length;
            if (n < m) // texto MENOR que o padrão
                return -1;
            for (i = 1; i < m; i++)
                dm = (d * dm) % q;
            for (i = 0; i < m; i++)
            {
                h1 = (h1 * d + p[i]) % q;
                h2 = (h2 * d + t[i]) % q;
            }
            for (i = 0; h1 != h2; i++)
            {
                if (i >= n - m) // chegou ao final do texto sem encontrar
                    return -1;
                h2 = (h2 + d * q - t[i] * dm) % q;
                h2 = (h2 * d + t[i + m]) % q;
            }
            return i;
        }
    }
}
