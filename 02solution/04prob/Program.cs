namespace _04prob;

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
        stack.Push(40);

        Stack<int> reversedStack = new Stack<int>();

        while (stack.Count > 0)
        {
            reversedStack.Push(stack.Pop());
        }

        Console.WriteLine("Reversed stack:");

        foreach (int item in reversedStack)
        {
            Console.WriteLine(item);
        }
    }
}
