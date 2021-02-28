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
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        List<int> elevatorFloor = new List<int>();
        List<int> elevatorPos = new List<int>();
        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            elevatorFloor.Add(int.Parse(inputs[0])); // floor on which this elevator is found
            elevatorPos.Add(int.Parse(inputs[1])); // position of the elevator on its floor
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            if (cloneFloor == -1 && clonePos == -1 && direction.Equals("NONE"))
                Console.WriteLine("WAIT");
            else if (cloneFloor < exitFloor)
            {
                int elevatorFloorIndex = elevatorFloor.IndexOf(elevatorFloor.Find(x => cloneFloor == x));
                if ((elevatorPos[elevatorFloorIndex] < clonePos && direction.Equals("RIGHT")) || (elevatorPos[elevatorFloorIndex] > clonePos && direction.Equals("LEFT")))
                    Console.WriteLine("BLOCK");
                else
                    Console.WriteLine("WAIT");
            }
            else if ((exitPos < clonePos && direction.Equals("RIGHT")) || (exitPos > clonePos && direction.Equals("LEFT")))
                Console.WriteLine("BLOCK");
            else
                Console.WriteLine("WAIT"); // action: WAIT or BLOCK

        }
    }
}