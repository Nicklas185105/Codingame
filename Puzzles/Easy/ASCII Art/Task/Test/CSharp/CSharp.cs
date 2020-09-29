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
        string[] testFile = System.IO.File.ReadAllLines(@"D:\Nicklas\Dokumenter\Codingame\Puzzles\Easy\ASCII Art\Task\Test\CSharp\MANHATTANWithAnotherASCIIRepresentation.txt");

        int L = int.Parse(testFile[0]);
        int H = int.Parse(testFile[1]);
        string T = testFile[2].ToUpper();

        for (int i = 0; i < H; i++)
        {
            string ROW = testFile[3 + i];

            for (int j = 0; j < T.Length; j++)
            {
                Console.Write(ROW.Substring((char.IsLetter(T[j]) ? (T[j] - 'A') : ('Z' - 'A' + 1)) * L, L));
            }

            Console.WriteLine();
        }
    }
}