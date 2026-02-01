using System;

class CifradoCesar
{
    static void Main()
    {
        string texto = "CIFRADOCESAR";
        int d = 5;
        string cifrado = "";

        foreach (char c in texto)
            cifrado += (char)('A' + (c - 'A' + d) % 26);

        Console.WriteLine("Plano: " + texto);
        Console.WriteLine("Cifrado: " + cifrado);

        string descifrado = "";
        foreach (char c in cifrado)
            descifrado += (char)('A' + (c - 'A' - d + 26) % 26);

        Console.WriteLine("Descifrado: " + descifrado);
        Console.WriteLine("Iguales: " + (texto == descifrado));
    }
}