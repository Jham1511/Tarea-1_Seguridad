using System;

class ejercicio_3
{
    static void Main()
    {
        string plano = "CIFRADOVIGENERE";
        string clave = "CLAVE";

        string cifrado = "";
        for (int i = 0; i < plano.Length; i++)
            cifrado += (char)('A' + (plano[i] - 'A' + (clave[i % clave.Length] - 'A')) % 26);

        string descifrado = "";
        for (int i = 0; i < cifrado.Length; i++)
            descifrado += (char)('A' + (cifrado[i] - 'A' - (clave[i % clave.Length] - 'A') + 26) % 26);

        Console.WriteLine("i.   Texto plano: " + plano);
        Console.WriteLine("ii.  Texto cifrado: " + cifrado);
        Console.WriteLine("iii. Texto descifrado: " + descifrado);
        Console.WriteLine("iv.  ¿Plano = Descifrado?: " + (plano == descifrado));
    }
}
