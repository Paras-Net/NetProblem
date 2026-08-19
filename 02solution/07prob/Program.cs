namespace _07prob;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Before removing:");
        Console.WriteLine("Count = " + stack.Count);

        stack.Clear();

        Console.WriteLine("After removing:");
        Console.WriteLine("Count = " + stack.Count);
    }
}