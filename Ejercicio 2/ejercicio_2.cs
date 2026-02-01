using System;
using System.Text;

class ejercicio_2
{
    static void Main()
    {
        string planoOriginal = "CIFRADOPLAYFAIR";
        string clave = "CLAVE";

        char[,] m = BuildMatrix(clave);
        string plano = PreparePlaintext(planoOriginal);

        string cifrado = Playfair(plano, m, true);
        string descifrado = Playfair(cifrado, m, false);

        Console.WriteLine("i.   Texto plano: " + plano);
        Console.WriteLine("ii.  Texto cifrado: " + cifrado);
        Console.WriteLine("iii. Texto descifrado: " + descifrado);
        Console.WriteLine("iv.  ¿Plano = Descifrado?: " + (plano == descifrado));
    }

    static string Clean(string s)
    {
        s = s.ToUpperInvariant();
        var sb = new StringBuilder();
        foreach (char ch in s)
            if (ch >= 'A' && ch <= 'Z') sb.Append(ch);
        return sb.ToString();
    }

    static char[,] BuildMatrix(string key)
    {
        bool[] used = new bool[26];
        used['J' - 'A'] = true;

        char[,] m = new char[5, 5];
        int k = 0;
        key = Clean(key);

        foreach (char ch in key)
        {
            char c = ch == 'J' ? 'I' : ch;
            int idx = c - 'A';
            if (!used[idx])
            {
                m[k / 5, k % 5] = c;
                used[idx] = true;
                k++;
            }
        }

        for (char c = 'A'; c <= 'Z'; c++)
        {
            if (c == 'J') continue;
            int idx = c - 'A';
            if (!used[idx])
            {
                m[k / 5, k % 5] = c;
                used[idx] = true;
                k++;
            }
        }
        return m;
    }

    static string PreparePlaintext(string text)
    {
        text = Clean(text).Replace('J', 'I');
        var sb = new StringBuilder();
        int i = 0;

        while (i < text.Length)
        {
            char a = text[i];
            char b = (i + 1 < text.Length) ? text[i + 1] : 'X';
            if (a == b) { sb.Append(a).Append('X'); i++; }
            else { sb.Append(a).Append(b); i += 2; }
        }
        if (sb.Length % 2 != 0) sb.Append('X');
        return sb.ToString();
    }

    static int Mod(int x, int m) => (x % m + m) % m;

    static void FindPos(char[,] m, char t, out int r, out int c)
    {
        for (r = 0; r < 5; r++)
            for (c = 0; c < 5; c++)
                if (m[r, c] == t) return;
        r = c = 0;
    }

    static string Playfair(string text, char[,] m, bool enc)
    {
        var o = new StringBuilder();
        for (int i = 0; i < text.Length; i += 2)
        {
            char a = text[i], b = text[i + 1];
            FindPos(m, a, out int r1, out int c1);
            FindPos(m, b, out int r2, out int c2);

            if (r1 == r2)
            {
                int sh = enc ? 1 : -1;
                o.Append(m[r1, Mod(c1 + sh, 5)]);
                o.Append(m[r2, Mod(c2 + sh, 5)]);
            }
            else if (c1 == c2)
            {
                int sh = enc ? 1 : -1;
                o.Append(m[Mod(r1 + sh, 5), c1]);
                o.Append(m[Mod(r2 + sh, 5), c2]);
            }
            else
            {
                o.Append(m[r1, c2]);
                o.Append(m[r2, c1]);
            }
        }
        return o.ToString();
    }
}