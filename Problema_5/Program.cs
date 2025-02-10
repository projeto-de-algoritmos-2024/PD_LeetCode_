using System;

class Program
{
    static string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1)
            return s;

        int start = 0, maxLength = 0;

        // Função para expandir ao redor do centro
        void ExpandAroundCenter(int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                int length = right - left + 1;
                if (length > maxLength)
                {
                    start = left;
                    maxLength = length;
                }
                left--;
                right++;
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            // Expande para palíndromos de comprimento ímpar
            ExpandAroundCenter(i, i);
            // Expande para palíndromos de comprimento par
            ExpandAroundCenter(i, i + 1);
        }

        return s.Substring(start, maxLength);
    }

    static void Main()
    {
        Console.WriteLine(LongestPalindrome("babad")); // Saída: "bab" ou "aba"
        Console.WriteLine(LongestPalindrome("cbbd"));  // Saída: "bb"
        Console.WriteLine(LongestPalindrome("a"));     // Saída: "a"
        Console.WriteLine(LongestPalindrome("ac"));    // Saída: "a" ou "c"
    }
}