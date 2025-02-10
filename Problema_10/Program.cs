using System;

class Program
{
    static bool IsMatch(string s, string p)
    {
        int m = s.Length, n = p.Length;
        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true; // Strings vazias correspondem

        // Preenchendo os casos onde * pode eliminar caracteres
        for (int j = 1; j <= n; j++)
        {
            if (p[j - 1] == '*')
                dp[0, j] = dp[0, j - 2]; // Remove o elemento antes de '*'
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == s[i - 1] || p[j - 1] == '.')
                {
                    dp[i, j] = dp[i - 1, j - 1]; // Caracteres combinam diretamente
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 2]; // Caso de remover o caractere antes de '*'

                    if (p[j - 2] == s[i - 1] || p[j - 2] == '.')
                    {
                        dp[i, j] = dp[i, j] || dp[i - 1, j]; // Caso de usar o '*' múltiplas vezes
                    }
                }
            }
        }

        return dp[m, n];
    }

    static void Main()
    {
        Console.WriteLine(IsMatch("aa", "a"));     // false
        Console.WriteLine(IsMatch("aa", "a*"));    // true
        Console.WriteLine(IsMatch("ab", ".*"));    // true
        Console.WriteLine(IsMatch("mississippi", "mis*is*p*.")); // false
        Console.WriteLine(IsMatch("mississippi", "mis*is*ip*.")); // true
    }
}