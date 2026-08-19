namespace _01Prob;
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
        Console.WriteLine("Stack elements:");
        foreach (int item in stack){Console.WriteLine(item);}
        Console.WriteLine("Top element: " + stack.Peek());
        Console.WriteLine("Popped element: " + stack.Pop());
        Console.WriteLine("Top element after pop: " + stack.Peek());
        if (stack.Count == 0){Console.WriteLine("Stack is empty");}
        else{Console.WriteLine("Stack is not empty");}
    }
}
