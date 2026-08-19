namespace prob1;
using System;
class Program
{
    static int MaximumGap(string s)
    {
        int maxGap = -1;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    int gap = j - i - 1;
                    if (gap > maxGap) maxGap = gap;
                }
            }
        }
        return maxGap;
    }

    static void Main()
    {
        string s = "socks";
        int result = MaximumGap(s);
        Console.WriteLine(result);
    }
}