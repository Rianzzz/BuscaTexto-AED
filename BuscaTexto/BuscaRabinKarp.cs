using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaTexto {
    class BuscaRabinKarp {
        const long q = 10014521L;
        const int d = 128;

        public static int RKSearch(String p, String t) {
            long dm = 1, h1 = 0, h2 = 0;
            int i;
            int m = p.Length;
            int n = t.Length;
            if (n < m) // texto MENOR que o padrão
                return -1;
            for (i = 1; i < m; i++)
                dm = (d * dm) % q;
            for (i = 0; i < m; i++) {
                h1 = (h1 * d + p[i]) % q;
                h2 = (h2 * d + t[i]) % q;
            }
            for (i = 0; h1 != h2; i++) {
                if (i >= n - m) // chegou ao final do texto sem encontrar
                    return -1;
                h2 = (h2 + d * q - t[i] * dm) % q;
                h2 = (h2 * d + t[i + m]) % q;
            }
            return i;
        }
    }
}
