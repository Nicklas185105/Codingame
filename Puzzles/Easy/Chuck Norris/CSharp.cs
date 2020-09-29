/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: Chuck Norris                     */
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
            string MESSAGE = Console.ReadLine();
            string binaryResult = string.Empty;
            string unaryResult = string.Empty;
            foreach (char m in MESSAGE)
            {
                string lengthCheck = Convert.ToString((int)m, 2);
                if (lengthCheck.Length < 7)
                {
                    lengthCheck = new string('0', 7- lengthCheck.Length) + lengthCheck;
                }
                binaryResult += lengthCheck;
            }
            
            unaryResult = binaryToUnary(binaryResult);
            
            Console.WriteLine(unaryResult.Trim());
        }

        public static string binaryToUnary(string binaryString)
        {
            char[] binaryArray = binaryString.ToArray();
           
            string unaryResponse = string.Empty;
            char lastChar = '\0';
            for (int i = 0; i<binaryArray.Length; i++)
            {
                char currentchar = binaryArray[i];
                if (lastChar != '1' && currentchar == '1')
                {
                    unaryResponse += " 0 0";
                    lastChar = '1';
                }
                else if (lastChar == '1' && currentchar == '1')
                {
                    unaryResponse += "0";
                }
                else if (lastChar != '0' && currentchar == '0')
                {
                    unaryResponse += " 00 0";
                    lastChar = '0';
                }
                else if (lastChar == '0' && currentchar == '0')
                {
                    unaryResponse += "0";
                }
                else
                {
                    unaryResponse += "error";
                }
            
             }
            return unaryResponse;

        }
}