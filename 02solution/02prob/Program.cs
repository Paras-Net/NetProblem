namespace _02prob;
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
        stack.Push(40);
        stack.Push(30);

        List<int> list = new List<int>(stack);

        list.Sort();
        list.Reverse();

        Stack<int> sortedStack = new Stack<int>();

        foreach (int item in list)
        {
            sortedStack.Push(item);
        }

        Console.WriteLine("Stack in descending order:");

        foreach (int item in sortedStack)
        {
            Console.WriteLine(item);
        }
    }
}
