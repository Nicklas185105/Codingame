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
        List<Player> players = new List<Player>(Enumerable.Range(0, N)
             .Select(x => Console.ReadLine().Split(' '))
             .Select(i => new Player() { number = int.Parse(i[0]), sign = i[1] }));

        var signs = new Dictionary<string, string>()
        {
            {"R", "LC"},
            {"P", "RS"},
            {"C", "PL"},
            {"L", "SP"},
            {"S", "CR"}
        };

        while (players.Count > 1)
        {
            var player1 = players.First();
            players.RemoveAt(0);
            var player2 = players.First();
            players.RemoveAt(0);

            bool player1Wins = player1.winsAgainst(player2, signs);
            if (player1Wins)
            {
                player1.wonAgainst.Add(player2.number);
                players.Add(player1);
            }
            else
            {
                player2.wonAgainst.Add(player1.number);
                players.Add(player2);
            }
        }
        Console.WriteLine(players.First().number);
        Console.WriteLine(string.Join(" ", players.First().wonAgainst));
    }

    class Player
    {
        public int number;
        public string sign;
        public List<int> wonAgainst = new List<int>();
        public bool winsAgainst(Player opponent, Dictionary<string, string> signs) => sign == opponent.sign ? number < opponent.number : (signs[sign].ToString().ToCharArray()[0].ToString().Equals(opponent.sign) || signs[sign].ToString().ToCharArray()[1].ToString().Equals(opponent.sign));
    }
}