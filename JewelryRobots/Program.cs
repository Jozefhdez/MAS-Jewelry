using System;
using System.Collections.Generic;

class Program
{
    // Simulation parameters
    static int gridSize = 10;
    static int Tmax = 200;
    static Random rand = new Random();

    // World state
    static List<Jewel> jewels = new List<Jewel>();
    static List<Robot> robots = new List<Robot>();

    static void Main()
    {
        Initialize();

        int steps = 0;
        while (steps < Tmax && jewels.Count > 0)
        {
            steps++;

            foreach (var robot in robots)
            {
                // TODO: decide action
                robot.Move();
            }

            DrawGrid();
            System.Threading.Thread.Sleep(200);
        }

        Console.WriteLine("Simulation finished in " + steps + " steps.");
    }

    static void Initialize()
    {
        // TODO: place jewels
        // TODO: place robots
    }

    static void DrawGrid()
    {
        Console.Clear();
        char[,] tempGrid = new char[gridSize, gridSize];

        // Fill grid with empty dots
        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                tempGrid[i, j] = '.';

        // TODO: draw jewels
        // TODO: draw robots

        // Print
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
                Console.Write(tempGrid[i, j] + " ");
            Console.WriteLine();
        }
    }
}
