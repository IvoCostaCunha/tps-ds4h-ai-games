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
        IDictionary<(int,int), bool> map = new Dictionary<(int,int), bool>();

        // Fill the IDictionary with false values (false == no wall, true == wall)
        // Goes from 0 to 31 for x and 0 to 21 to Y
        // 0 and 31 and 0 and 21 being the border walls
        for(int x = 0; x < 31; x++) {
            for(int y = 0; y < 21; y++) {
                if((x == 0) || (x == 31) || (y == 0) || (y == 21)) {
                    map.Add((x,y),true);
                }
                else map.Add((x,y),false);
            }
        }

        string[] inputs;

        string direction = "DOWN";
        bool obstacle = false;

        
        // game loop
        while (true)
        {

            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // total number of players (2 to 4).
            int P = int.Parse(inputs[1]); // your player number (0 to 3).
            for (int i = 0; i < N; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                //int X0 = int.Parse(inputs[0]); // starting X coordinate of lightcycle (or -1)
                //int Y0 = int.Parse(inputs[1]); // starting Y coordinate of lightcycle (or -1)
                int X1 = int.Parse(inputs[2]); // starting X coordinate of lightcycle (can be the same as X0 if you play before this player)
                int Y1 = int.Parse(inputs[3]); // starting Y coordinate of lightcycle (can be the same as Y0 if you play before this player)

                //int X0s = X0++;
                //int Y0s = Y0++;

                // Parsed round coordiantes are in values from 0 to 29 but we add 2 to simulate 
                // invisible walls so we increment by 1 ( 0 would became 1)
                int X1s = X1++;
                int Y1s = Y1++;

                // When an opposant plays
                if(i != P) {
                    map[(X1s,Y1s)] = true;
                }

                // When the player plays
                else if(i == P){
                    map[(X1s,Y1s)] = true;

                    // Check if next movement will lead to an obstacle
                    if(direction == "DOWN") {
                        if(map[(X1s,Y1-1)]) {
                            obstacle = true;
                        }
                    }
                    else if(direction == "UP") {
                        if(map[(X1s,Y1+1)]) {
                            obstacle = true;
                        }
                    }  
                    else if(direction == "RIGHT") {
                        if(map[(X1s+1,Y1)]) {
                            obstacle = true;
                        }
                    }  
                    else if(direction == "LEFT") {
                        if(map[(X1s-1,Y1)]) {
                            obstacle = true;
                        }
                    }

                    if(obstacle) {
                        // if UP or DOWN
                        if((direction == "DOWN") || (direction == "UP")) {
                            if(!map[(X1s+1,Y1)]) { direction = "RIGHT"; }
                            else {direction = "LEFT";}
                            obstacle = false;
                        }

                        // if LEFT or RIGHT
                        else {
                            if(!map[(X1s,Y1+1)]) { direction = "DOWN"; }
                            else {direction = "UP";}
                            obstacle = false;
                        }
                    }           

                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(direction); // A single line with UP, DOWN, LEFT or RIGHT

        }
    }
}