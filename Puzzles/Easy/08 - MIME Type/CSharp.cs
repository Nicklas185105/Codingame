/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: MIME Type                        */
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
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

        string[] EXT = new string[N];
        string[] MT = new string[N];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            EXT[i] = inputs[0].ToLower(); // file extension
            MT[i] = inputs[1]; // MIME type.
        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine().ToLower(); // One file name per line.

            string[] temp = FNAME.Split('.');

            if (temp.Length > 1 && EXT.Contains(temp.Last())){
                    Console.WriteLine(MT[Array.IndexOf(EXT, temp.Last())]);
            }
            else {
                    Console.WriteLine("UNKNOWN");
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
        //Console.WriteLine("UNKNOWN");
    }
}