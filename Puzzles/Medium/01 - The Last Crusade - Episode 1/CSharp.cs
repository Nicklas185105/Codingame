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
class Player
{
    static void Main(string[] args)
    {
        #region Dictionary Setup
        Dictionary<string, Dictionary<string,string>> mapRules = new Dictionary<string, Dictionary<string, string>>();
        mapRules.Add("1", new Dictionary<string, string>(){{"LEFT", "BOTTOM"},{"TOP", "BOTTOM"},{"RIGHT", "BOTTOM"}});
        mapRules.Add("2", new Dictionary<string, string>(){{"LEFT", "RIGHT"},{"RIGHT", "LEFT"}});
        mapRules.Add("3", new Dictionary<string, string>(){{"TOP", "BOTTOM"}});
        mapRules.Add("4", new Dictionary<string, string>(){{"TOP", "LEFT"},{"RIGHT", "BOTTOM"}});
        mapRules.Add("5", new Dictionary<string, string>(){{"TOP", "RIGHT"},{"LEFT", "BOTTOM"}});
        mapRules.Add("6", new Dictionary<string, string>(){{"LEFT", "RIGHT"},{"RIGHT", "LEFT"}});
        mapRules.Add("7", new Dictionary<string, string>(){{"TOP", "BOTTOM"},{"RIGHT", "BOTTOM"}});
        mapRules.Add("8", new Dictionary<string, string>(){{"LEFT", "BOTTOM"},{"RIGHT", "BOTTOM"}});
        mapRules.Add("9", new Dictionary<string, string>(){{"LEFT", "BOTTOM"},{"TOP", "BOTTOM"}});
        mapRules.Add("10", new Dictionary<string, string>(){{"TOP", "LEFT"}});
        mapRules.Add("11", new Dictionary<string, string>(){{"TOP", "RIGHT"}});
        mapRules.Add("12", new Dictionary<string, string>(){{"RIGHT", "BOTTOM"}});
        mapRules.Add("13", new Dictionary<string, string>(){{"LEFT", "BOTTOM"}});

        Dictionary<string, Dictionary<string, int>> dirRules = new Dictionary<string, Dictionary<string, int>>();
        dirRules.Add("LEFT", new Dictionary<string, int>(){{"y", 0},{"x", -1}});
        dirRules.Add("RIGHT", new Dictionary<string, int>(){{"y", 0},{"x", 1}});
        dirRules.Add("BOTTOM", new Dictionary<string, int>(){{"y", 1},{"x", 0}});
        #endregion

        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        List<List<string>> map = new List<List<string>>();
        for (int i = 0; i < H; i++)
        {
            // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            map.Add(Console.ReadLine().Split(' ').ToList());
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POS = inputs[2];

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            
            var rule = dirRules[mapRules[map[YI][XI]][POS]];
            var x_to = XI + rule["x"];
            var y_to = YI + rule["y"];

            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine(x_to + " " + y_to);
        }
    }
}