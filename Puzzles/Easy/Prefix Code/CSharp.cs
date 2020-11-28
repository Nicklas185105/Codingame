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
        int n = int.Parse(Console.ReadLine());
        string[] b = new string[n];
        int[] c = new int[n];
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            b[i] = inputs[0];
            c[i] = int.Parse(inputs[1]);
        }
        string text = Console.ReadLine();
        //Console.Error.WriteLine(text);
        char[] s = text.ToCharArray();

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        string result = "";
        int m = 0;
        int index = 0;

        while(s.Length > 0)
        {
            //Console.Error.WriteLine(s.Length);
            for (int i = b.Length-1; i >= 0; i--)
            {
                bool match = false;
                //Console.Error.WriteLine(b[i].ToCharArray().Length <= s.Length);
                if (b[i].ToCharArray().Length <= s.Length)
                {
                    //Console.Error.Write(b[i]);
                    if (b[i].Equals(text.Substring(0,b[i].Length)))
                        match = true;

                    if (match && s.Length == 1)
                    {
                        result += char.ConvertFromUtf32(c[i]);
                        List<char> list = new List<char>(s);
                        list.Clear();
                        s = list.ToArray();
                    }
                    else if (match)
                    {
                        result += char.ConvertFromUtf32(c[i]);
                        List<char> list = new List<char>(s);
                        foreach (char j in b[i].ToString().ToCharArray())
                        {
                            list.RemoveAt(0);
                            index++;
                        }
                        s = list.ToArray();
                        text = new string(s);
                        m = 0;
                        break;
                    }
                }
                m++;
            }
            if (m > b.Length || b.Length == 0 || c.Length == 0)
            {
                Console.WriteLine("DECODE FAIL AT INDEX " + index);
                return;
            }
            //Console.Error.WriteLine(result);
        }

        Console.WriteLine(result);
    }
}