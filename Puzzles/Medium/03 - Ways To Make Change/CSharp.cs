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
        int S = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        int[] vi = new int[S];
        for (int i = 0; i < S; i++)
        {
            vi[i] = int.Parse(inputs[i]);
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(FindCombinationsCount(N, vi).ToString());
    }

    // "Dynamic Programming" implementation 
    public static int FindCombinationsCount(int sum, int[] vals)
    {
        if (sum < 0)
        {
            return 0;
        }
        if (vals == null || vals.Length == 0)
        {
            return 0;
        }

        int[] dp = new int[sum + 1];
        dp[0] = 1;
        for (int i = 0; i < vals.Length; ++i)
        {
            for (int j = vals[i]; j <= sum; ++j)
            {
                dp[j] += dp[j - vals[i]];
            }
        }

        return dp[sum]; 
    }
}