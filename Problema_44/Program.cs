using System;

class Program
{
    static bool IsMatch(string s, string p)
    {
        int m = s.Length, n = p.Length;
        bool[,] dp = new bool[m + 1, n + 1];

        // Caso base: strings vazias correspondem
        dp[0, 0] = true;

        // Inicializar os casos onde o padrão começa com '*'
        for (int j = 1; j <= n; j++)
        {
            if (p[j - 1] == '*')
                dp[0, j] = dp[0, j - 1]; // '*' pode representar uma string vazia
        }

        // Preenchendo a matriz DP
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == s[i - 1] || p[j - 1] == '?')
                {
                    dp[i, j] = dp[i - 1, j - 1]; // Caracteres combinam ou '?' substitui qualquer um
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 1] || dp[i - 1, j]; 
                    // '*' pode representar uma string vazia (dp[i, j-1]) ou consumir um caractere (dp[i-1, j])
                }
            }
        }

        return dp[m, n];
    }

    static void Main()
    {
        Console.WriteLine(IsMatch("aa", "a"));     // false
        Console.WriteLine(IsMatch("aa", "*"));     // true
        Console.WriteLine(IsMatch("cb", "?a"));    // false
        Console.WriteLine(IsMatch("adceb", "*a*b"));// true
        Console.WriteLine(IsMatch("acdcb", "a*c?b"));// false
    }
}
