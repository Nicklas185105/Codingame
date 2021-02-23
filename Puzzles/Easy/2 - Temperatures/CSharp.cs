/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: Temperatures                     */
/* Difficulty: Easy                         */
/* Date solved: 29.09.2020                  */
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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        int[] temp = new int[n];
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            temp[i] = t;
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        if (n==0){
            Console.WriteLine(0);
        }else{
            int c = temp[0];
            for (int i = 1; i < n; i++){
                if (Math.Abs(temp[i]) == Math.Abs(c) && temp[i] != c)
                    c = Math.Abs(temp[i]);
                else if (Math.Abs(temp[i]) < Math.Abs(c))
                    c = temp[i];
            }
            if (n!=0)
                Console.WriteLine(c);
            else
                Console.WriteLine(0);
        }
    }
}