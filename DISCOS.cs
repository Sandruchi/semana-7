using System;
using System.Collections.Generic;

class Torre
{
    public Stack<int> Discos { get; } = new Stack<int>();
    public string Nombre { get; }

    public Torre(string nombre)
    {
        Nombre = nombre;
    }
}

class TorresDeHanoi
{
    static void MoverDiscos(int n, Torre origen, Torre destino, Torre auxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Discos.Pop();
            destino.Discos.Push(disco);
            Console.WriteLine($"Mover disco {disco} desde {origen.Nombre} hacia {destino.Nombre}");
        }
        else
        {
            MoverDiscos(n - 1, origen, auxiliar, destino);
            MoverDiscos(1, origen, destino, auxiliar);
            MoverDiscos(n - 1, auxiliar, destino, origen);
        }
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        int n = int.Parse(Console.ReadLine());

        Torre origen = new Torre("Origen");
        Torre destino = new Torre("Destino");
        Torre auxiliar = new Torre("Auxiliar");

        // Carga inicial de discos en la torre de origen
        for (int i = n; i >= 1; i--)
        {
            origen.Discos.Push(i);
        }

        Console.WriteLine("\nPasos para resolver Torres de Hanoi:\n");
        MoverDiscos(n, origen, destino, auxiliar);
    }
}
