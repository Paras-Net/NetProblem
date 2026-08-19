using System;
namespace prob2;
class Program
{
    static string MirrorCharacters(string s, int k)
    {
        char[] chars = s.ToCharArray();
        int start = k - 1;
        for (int i = start; i < chars.Length; i++)
        {
            chars[i] = (char)('z' - (chars[i] - 'a'));
        }
        return new string(chars);
    }
    static void Main()
    {
        string s = "geeksforgeeks";
        int k = 5;
        string result = MirrorCharacters(s, k);
        Console.WriteLine(result);
    }
}
