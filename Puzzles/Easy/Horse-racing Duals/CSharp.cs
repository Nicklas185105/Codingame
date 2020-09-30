/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: Horse-racing Duals               */
/* Difficulty: Easy                         */
/* Date solved: 30.09.2020                  */
/*                                          */
/********************************************/

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
        int N = int.Parse(Console.ReadLine());
        List<int> pi = new List<int>();
        for (int i = 0; i < N; i++)
        {
            pi.Add(int.Parse(Console.ReadLine()));
            Console.Error.WriteLine(pi[i]);
        }

        pi.Sort();

        int n = 0;
        int m = 0;
        int d = int.MaxValue;
        for(int i = 0; i < N; i++)
        {
            n = pi[i];
            if (n - m < d){
                d = n - m;
            }
            m = n;
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(d);
    }
}