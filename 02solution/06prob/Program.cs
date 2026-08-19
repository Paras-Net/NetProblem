namespace _06prob;

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

        int min = int.MaxValue;

        foreach (int item in stack)
        {
            if (item < min)
            {
                min = item;
            }
        }

        Console.WriteLine("Minimum element: " + min);
    }
}