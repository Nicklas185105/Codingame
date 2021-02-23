/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: Rock Paper Scissors Lizard Spock */
/* Difficulty: Easy                         */
/* Date solved: 30.11.2020                  */
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
        var players = Enumerable.Range(0, N)
            .Select(x => Console.ReadLine().Split(' '))
            .ToDictionary(i => i[0], i => Convert.ToChar(i[1]));

        string[] wins = new string[N];
        for (int i = 0; i < N; i++)
        {
            wins[i] = "";
        }
        var signs = new Dictionary<string, string>()
        {
            {"R", "L C"},
            {"P", "R S"},
            {"C", "P L"},
            {"L", "S P"},
            {"S", "C R"}
        };

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        int player1 = 0;
        int player2 = 0; 

        Console.Error.WriteLine((int)Math.Log(32, 2));

        for (int j = 0; j < (int)Math.Log(N,2); j++)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Error.WriteLine(players.ElementAt(i).Key + " | " + i + " | " + player1 + " " + player2);   
                if (player1 == 0)
                    player1 = (wins[int.Parse(players.ElementAt(i).Key)-1].Equals(string.Empty) && j > 0) ? 0 : int.Parse(players.ElementAt(i).Key);
                else if (player2 == 0)
                    player2 = (wins[int.Parse(players.ElementAt(i).Key)-1].Equals(string.Empty) && j > 0) ? 0 : int.Parse(players.ElementAt(i).Key);
                
                if (player1 != 0 && player2 != 0)
                {
                    signs.TryGetValue(players[player1.ToString()].ToString(), out string value1);
                    signs.TryGetValue(players[player2.ToString()].ToString(), out string value2);
                    
                    Console.Error.WriteLine(players[player1.ToString()] + " " + players[player2.ToString()]);
                    
                    if (value1.ToCharArray().ToList().Exists(x => x.Equals(players[player2.ToString()])))
                    {
                        wins[player2-1] = string.Empty;
                        if (j == 0)
                            wins[player1-1] = player2.ToString();
                        else
                            wins[player1-1] += " " + player2;
                        Console.Error.WriteLine(player1 + " | " + wins[player1-1] + " " + wins[player2-1]);
                    }
                    else if (value2.ToCharArray().ToList().Exists(x => x.Equals(players[player1.ToString()])))
                    {
                        wins[player1-1] = string.Empty;
                        if (j == 0)
                            wins[player2-1] = player1.ToString();
                        else
                            wins[player2-1] += " " + player1;
                        Console.Error.WriteLine(player2 + " | " + wins[player2-1] + " " + wins[player1-1]);
                    }
                    else
                    {
                        if (player1 < player2)
                        {
                            wins[player2-1] = string.Empty;
                            if (j == 0)
                                wins[player1-1] = player2.ToString();
                            else
                                wins[player1-1] += " " + player2;
                            Console.Error.WriteLine(player1 + " | " + wins[player1-1] + " " + wins[player2-1]);
                        }
                        else
                        {
                            wins[player1-1] = string.Empty;
                            if (j == 0)
                                wins[player2-1] = player1.ToString();
                            else
                                wins[player2-1] += " " + player1;
                            Console.Error.WriteLine(player2 + " | " + wins[player2-1] + " " + wins[player1-1]);
                        }
                    }
                    /*if (players[player1.ToString()].Equals('R') && players[player2.ToString()].Equals('P'))
                    {
                        Console.WriteLine("1");
                        Console.WriteLine("4");
                        return;
                    }*/

                    player1 = 0;
                    player2 = 0;
                }
                    
            }
        }

        for(int i = 0; i < wins.Length; i++)
        {
            if (!wins[i].Equals(string.Empty))
            {
                Console.WriteLine(i+1);
                Console.WriteLine(wins[i]);
            }
        }

        //Console.WriteLine("WHO IS THE WINNER?");
    }
}