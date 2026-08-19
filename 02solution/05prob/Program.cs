namespace _05prob;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(10);
        stack.Push(50);
        stack.Push(20);
        stack.Push(80);
        stack.Push(30);

        int max = int.MinValue;

        foreach (int item in stack)
        {
            if (item > max)
            {
                max = item;
            }
        }

        Console.WriteLine("Maximum element: " + max);
    }
}
