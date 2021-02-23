using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<string, int> resistanceValues = new Dictionary<string, int>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string name = inputs[0];
            int R = int.Parse(inputs[1]);
            resistanceValues[name] = R;
        }
        var circuit = Console.ReadLine();
        string[] circuitSplit = circuit.Split(' ');
        Stack<string> stack = new Stack<string>();
        Console.Error.WriteLine(circuit);

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        
        for (int i = 0; i < circuitSplit.Length; i++)
        {
            string stringAtI = circuitSplit[i];
            if (!("]".Equals(stringAtI) || ")".Equals(stringAtI)))
            {
                if("[".Equals(stringAtI) || "(".Equals(stringAtI)) 
                {
                    stack.Push(stringAtI);
                } 
                else 
                {
                    stack.Push(resistanceValues[stringAtI].ToString());
                }
            }
            else
            {
                if (")".Equals(stringAtI)) 
                {
                    Double resistanceResult = 0.0;
                    String resistor = stack.Pop();
                    while (!"(".Equals(resistor)) {
                        resistanceResult += Double.Parse(resistor);
                        resistor = stack.Pop();
                    }
                    stack.Push(resistanceResult.ToString());
                } 
                else 
                {
                    Double resistanceResult = 0.0;
                    String resistor = stack.Pop();
                    while (!"[".Equals(resistor)) {
                        resistanceResult += 1 / Double.Parse(resistor);
                        resistor = stack.Pop();
                    }
                    resistanceResult = 1 / resistanceResult;
                    stack.Push(resistanceResult.ToString());
                }
            }
        }
        
        /*DataTable dt = new DataTable();
        var v = Convert.ToSingle(dt.Compute(result,""));
        Console.WriteLine(v.ToString("#.0"));*/
        Console.WriteLine(Double.Parse(stack.Pop()).ToString("#.0"));
    }
}