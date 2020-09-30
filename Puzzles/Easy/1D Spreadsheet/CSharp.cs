/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: 1D SpreadSheet                   */
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
        string[] operation = new string[N];
        string[] arg1 = new string[N];
        string[] arg2 = new string[N];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            operation[i] = inputs[0];
            arg1[i] = inputs[1];
            arg2[i] = inputs[2];

            Console.Error.WriteLine(operation[i] + " | " + arg1[i] + " | " + arg2[i]);
        }
        int[] output = new int[N];
        for (int i = 0; i < N; i++)
        {

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            if (output[i] != 0)
                continue;

            if(operation[i].Equals("VALUE"))
                output[i] = VALUE(arg1, arg2, output, i, operation, false);
            else
            {
                if (operation[i].Equals("ADD"))
                {
                    output[i] = ADD(arg1, arg2, output, i, operation, false);
                }
                else if (operation[i].Equals("SUB"))
                {
                    output[i] = SUB(arg1, arg2, output, i, operation, false);
                }
                else // MULT
                {
                    output[i] = MULT(arg1, arg2, output, i, operation, false);
                }
            }
        }

        foreach(int n in output)
            Console.WriteLine(n);
    }

    static int VALUE(string[] arg1, string[] arg2, int[] output, int i, string[] operation, bool newI)
    {
        Console.Error.WriteLine("CALLED");
        if (arg1[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);

            bool ta = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            return (ta ? a : output[a]);
        }
        else
            return int.Parse(arg1[i]);
    }

    static int ADD(string[] arg1, string[] arg2, int[] output, int i, string[] operation, bool newI)
    {
        if (arg1[i].Split('$').First().Equals(string.Empty) && arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);
            int.TryParse(arg2[i].Split('$').Last(), out int b);
            
            bool ta = false;
            bool tb = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            
            return (ta ? a : output[a]) + (tb ? b : output[b]);
        }
        else if (arg1[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);
            
            bool ta = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            return (ta ? a : output[a]) + int.Parse(arg2[i]);
        }
        else if (arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg2[i].Split('$').Last(), out int b);

            bool tb = false;

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            return int.Parse(arg1[i]) + (tb ? b : output[b]);
        }
        else
        {
            int.TryParse(arg1[i], out int a);
            int.TryParse(arg2[i], out int b);
            return a + b;
        }
    }

    static int SUB(string[] arg1, string[] arg2, int[] output, int i, string[] operation, bool newI)
    {
        if (arg1[i].Split('$').First().Equals(string.Empty) && arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);
            int.TryParse(arg2[i].Split('$').Last(), out int b);
            
            bool ta = false;
            bool tb = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            
            return (ta ? a : output[a]) - (tb ? b : output[b]);
        }
        else if (arg1[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);

            bool ta = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            return (ta ? a : output[a]) - int.Parse(arg2[i]);
        }
        else if (arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg2[i].Split('$').Last(), out int b);

            bool tb = false;

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            return int.Parse(arg1[i]) - (tb ? b : output[b]);
        }
        else
        {
            int.TryParse(arg1[i], out int a);
            int.TryParse(arg2[i], out int b);
            return a - b;
        }
    }

    static int MULT(string[] arg1, string[] arg2, int[] output, int i, string[] operation, bool newI)
    {
        if (arg1[i].Split('$').First().Equals(string.Empty) && arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);
            int.TryParse(arg2[i].Split('$').Last(), out int b);
            
            bool ta = false;
            bool tb = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            
            return (ta ? a : output[a]) * (tb ? b : output[b]);
        }
        else if (arg1[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg1[i].Split('$').Last(), out int a);

            bool ta = false;
            if ((a > i || newI) && output[a] == 0)
            {
                ta = true;
                int temp = a;
                if (operation[a].Equals("VALUE"))
                    a = VALUE(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("ADD"))
                    a = ADD(arg1, arg2, output, a, operation, true);
                else if (operation[a].Equals("SUB"))
                    a = SUB(arg1, arg2, output, a, operation, true);
                else
                    a = MULT(arg1, arg2, output, a, operation, true);

                output[temp] = a;
            }

            return (ta ? a : output[a]) * int.Parse(arg2[i]);
        }
        else if (arg2[i].Split('$').First().Equals(string.Empty))
        {
            int.TryParse(arg2[i].Split('$').Last(), out int b);

            bool tb = false;

            if ((b > i || newI) && output[b] == 0)
            {
                tb = true;
                int temp = b;
                if (operation[b].Equals("VALUE"))
                    b = VALUE(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("ADD"))
                    b = ADD(arg1, arg2, output, b, operation, true);
                else if (operation[b].Equals("SUB"))
                    b = SUB(arg1, arg2, output, b, operation, true);
                else
                    b = MULT(arg1, arg2, output, b, operation, true);

                output[temp] = b;
            }
            return int.Parse(arg1[i]) * (tb ? b : output[b]);
        }
        else
        {
            int.TryParse(arg1[i], out int a);
            int.TryParse(arg2[i], out int b);
            return a * b;
        }
    }
}