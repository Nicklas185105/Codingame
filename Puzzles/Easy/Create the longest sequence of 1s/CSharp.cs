using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string b = Console.ReadLine();
        Console.Error.WriteLine(b);
        char[] charArr = b.ToCharArray();

        int oneBefore = 0;
        int oneAfter = 0;
        int result = 0;
        bool after = false;

        foreach (char ch in charArr)
        {
            if (!after && ch.Equals('1'))
            {
                oneBefore++;
            }
            else if (after && ch.Equals('1'))
            {
                oneAfter++;
            }
            else if(!after && ch.Equals('0'))
            {
                if ((oneBefore + oneAfter + 1) > result)
                    result = oneBefore + oneAfter + 1;

                after = true;
            }
            else if (after && ch.Equals('0'))
            {
                if ((oneBefore + oneAfter + 1) > result)
                    result = oneBefore + oneAfter + 1;
                    
                oneBefore = oneAfter;
                oneAfter = 0;
            }
        }

        if ((oneBefore + oneAfter + 1) > result)
            result = oneBefore + oneAfter + 1;

        if (!charArr.Contains('1'))
        {
            Console.WriteLine("1");
        }
        else
        {
            Console.WriteLine(result);
        }
    }
}