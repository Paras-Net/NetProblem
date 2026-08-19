using System;
namespace Prob3;
class Program
{
    static int LastIndexOfCharacter(string s, char x)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == x)return i;
        }
        return -1;
    }

    static void Main()
    {
        string s = "Geeks";
        char x = 'e';
        int result = LastIndexOfCharacter(s, x);
        Console.WriteLine(result);
    }
}