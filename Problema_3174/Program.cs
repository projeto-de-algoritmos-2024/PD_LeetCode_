using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static string ClearDigits(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                // Remove o caractere não numérico mais próximo à esquerda, se existir
                if (stack.Count > 0)
                    stack.Pop();
            }
            else
            {
                stack.Push(c);
            }
        }

        // Reconstroi a string final a partir da pilha
        StringBuilder result = new StringBuilder();
        foreach (char c in stack)
        {
            result.Insert(0, c);
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine(ClearDigits("abc"));  // Saída: "abc"
        Console.WriteLine(ClearDigits("cb34")); // Saída: ""
        Console.WriteLine(ClearDigits("a1b2c3d4")); // Saída: ""
        Console.WriteLine(ClearDigits("abcde1234")); // Saída: "a"
    }
}
