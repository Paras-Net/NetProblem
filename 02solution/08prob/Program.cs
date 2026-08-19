namespace _08prob;
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
        stack.Push(50);
        int valueToRemove = 30;
        Stack<int> temp = new Stack<int>();
        while (stack.Count > 0)
        {
            int value = stack.Pop();
            if (value != valueToRemove)
            {
                temp.Push(value);
            }
        }
        while (temp.Count > 0)
        {
            stack.Push(temp.Pop());
        }

        Console.WriteLine("Stack after removing " + valueToRemove + ":");

        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }
    }
}