using System;

class ejercicio_1
{
    static void Main()
    {
        string textoPlano = "CIFRADOCESAR";
        int desplazamiento = 5;
        string cifrado = "";


        foreach (char c in textoPlano)
            cifrado += (char)('A' + (c - 'A' + desplazamiento) % 26);


        string descifrado = "";
        foreach (char c in cifrado)
            descifrado += (char)('A' + (c - 'A' - desplazamiento + 26) % 26);

        Console.WriteLine("Texto plano: " + textoPlano);
        Console.WriteLine("Texto cifrado: " + cifrado);
        Console.WriteLine("Texto descifrado: " + descifrado);
        Console.WriteLine("¿Plano = Descifrado?: " + (textoPlano == descifrado));
    }
}
