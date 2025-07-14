using System;
using System.Collections.Generic;

class VerificadorBalanceo
{
    static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c); // Apila el carácter de apertura
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;

                char apertura = pila.Pop(); // Extrae el último carácter abierto

                if (!Coinciden(apertura, c)) return false;
            }
        }

        return pila.Count == 0; // Si la pila está vacía, está balanceado
    }

    static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }

    static void Main()
    {
        Console.WriteLine("Ingrese la expresión:");
        string expresion = Console.ReadLine();

        if (EstaBalanceado(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}

