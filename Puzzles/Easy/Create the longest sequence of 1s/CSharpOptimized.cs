using System;

class Solution
{
    static void Main()
    {
        var b = Console.ReadLine().Split('0');
        var max = 0;
        for (var i = 0; i < b.Length - 1; i++) max = Math.Max(b[i].Length + b[i + 1].Length, max);
        Console.WriteLine(max + 1);
    }
}