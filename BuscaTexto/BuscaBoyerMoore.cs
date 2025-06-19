using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaTexto {
    class BuscaBoyerMoore {
        static int[] skip = new int[256];

        public static void initSkip(String p) {
            int j, m = p.Length;
            for (j = 0; j < 256; j++)
                skip[j] = m;
            for (j = 0; j < m; j++)
                skip[p[j]] = m - j - 1;
        }

        public static int BMSearch(String p, String t) {
            int i, j, a, m = p.Length, n = t.Length;
            i = m - 1;
            j = m - 1;
            initSkip(p);
            while (j >= 0) {
                while (t[i] != p[j]) {
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
