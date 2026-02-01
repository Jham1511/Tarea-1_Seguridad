using System;

class ejercicio_4
{
    static void Main()
    {
        string plano = "CIFRADORAILFENCE";
        int rieles = 3;

        string cifrado = Encrypt(plano, rieles);
        string descifrado = Decrypt(cifrado, rieles);

        Console.WriteLine("i.   Texto plano: " + plano);
        Console.WriteLine("ii.  Texto cifrado: " + cifrado);
        Console.WriteLine("iii. Texto descifrado: " + descifrado);
        Console.WriteLine("iv.  ¿Plano = Descifrado?: " + (plano == descifrado));
    }

    static string Encrypt(string text, int rails)
    {
        string[] r = new string[rails];
        int row = 0, dir = 1;

        foreach (char c in text)
        {
            r[row] += c;
            if (row == 0) dir = 1;
            else if (row == rails - 1) dir = -1;
            row += dir;
        }

        return r[0] + r[1] + r[2];
    }

    static string Decrypt(string cipher, int rails)
    {
        int n = cipher.Length;

        bool[,] mark = new bool[rails, n];
        int row = 0, dir = 1;

        for (int col = 0; col < n; col++)
        {
            mark[row, col] = true;
            if (row == 0) dir = 1;
            else if (row == rails - 1) dir = -1;
            row += dir;
        }

        char[,] grid = new char[rails, n];
        int idx = 0;

        for (int r = 0; r < rails; r++)
            for (int c = 0; c < n; c++)
                if (mark[r, c]) grid[r, c] = cipher[idx++];

        char[] plain = new char[n];
        row = 0; dir = 1;

        for (int col = 0; col < n; col++)
        {
            plain[col] = grid[row, col];
            if (row == 0) dir = 1;
            else if (row == rails - 1) dir = -1;
            row += dir;
        }

        return new string(plain);
    }
}