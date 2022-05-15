/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: ASCII Art                        */
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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpper();

        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();

            for (int j = 0; j < T.Length; j++)
            {
                Console.Write(ROW.Substring((char.IsLetter(T[j]) ? (T[j] - 'A') : ('Z' - 'A' + 1)) * L, L));
            }

            Console.WriteLine();
        }
    }
}