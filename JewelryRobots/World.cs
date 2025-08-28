using System;
using System.Collections.Generic;

class World
{
    public int numRedJewels = 4;
    public int numGreenJewels = 4;
    public int numBlueJewels = 4;
    public int U = 7;
    public int V = 7;
    public Cell[,] grid = null!;
    public int seed = -1;
    public System.Random rng = null!;
    public Robot robotRed = null!;
    public Robot robotGreen = null!;
    public Robot robotBlue = null!;
    public List<Jewel> jewels = null!;

    public void Start()
    {
        rng = (seed < 0) ? new System.Random() : new System.Random(seed);
        InitWorld();
    }

    void InitWorld()
    {
        // create grid
        // U = width
        // V = height
        grid = new Cell[U, V];
        for (int x = 0; x < U; x++)
            for (int y = 0; y < V; y++)
                grid[x, y] = new Cell(x, y);

        // Initialize jewels list
        jewels = new List<Jewel>();

        // place robots at random positions
        robotRed = new Robot();
        robotRed.Color = 'R';
        robotBlue = new Robot();
        robotBlue.Color = 'B';
        robotGreen = new Robot();
        robotGreen.Color = 'G';

        // Place red robot
        robotRed.X = rng.Next(U);
        robotRed.Y = rng.Next(V);
        grid[robotRed.X, robotRed.Y].state = CellState.robot;

        // Place blue robot
        do
        {
            robotBlue.X = rng.Next(U);
            robotBlue.Y = rng.Next(V);
        } while (grid[robotBlue.X, robotBlue.Y].state != CellState.free);
        grid[robotBlue.X, robotBlue.Y].state = CellState.robot;

        // Place green robot
        do
        {
            robotGreen.X = rng.Next(U);
            robotGreen.Y = rng.Next(V);
        } while (grid[robotGreen.X, robotGreen.Y].state != CellState.free);
        grid[robotGreen.X, robotGreen.Y].state = CellState.robot;

        // Create and place red jewels
        for (int i = 0; i < numRedJewels; i++)
        {
            Jewel jewel = new Jewel();
            jewel.Color = 'R';
            do
            {
                jewel.X = rng.Next(U);
                jewel.Y = rng.Next(V);
            } while (grid[jewel.X, jewel.Y].state != CellState.free);

            grid[jewel.X, jewel.Y].state = CellState.jewel;
            grid[jewel.X, jewel.Y].LayingJewel = jewel;
            jewels.Add(jewel);
        }

        // Create and place green jewels
        for (int i = 0; i < numGreenJewels; i++)
        {
            Jewel jewel = new Jewel();
            jewel.Color = 'G';
            do
            {
                jewel.X = rng.Next(U);
                jewel.Y = rng.Next(V);
            } while (grid[jewel.X, jewel.Y].state != CellState.free);

            grid[jewel.X, jewel.Y].state = CellState.jewel;
            grid[jewel.X, jewel.Y].LayingJewel = jewel;
            jewels.Add(jewel);
        }

        // Create and place blue jewels
        for (int i = 0; i < numBlueJewels; i++)
        {
            Jewel jewel = new Jewel();
            jewel.Color = 'B';
            do
            {
                jewel.X = rng.Next(U);
                jewel.Y = rng.Next(V);
            } while (grid[jewel.X, jewel.Y].state != CellState.free);

            grid[jewel.X, jewel.Y].state = CellState.jewel;
            grid[jewel.X, jewel.Y].LayingJewel = jewel;
            jewels.Add(jewel);
        }
        
        // Create target zones for red jewels
        for (int i = 0; i < numRedJewels; i++)
        {
            int targetX, targetY;
            do { 
                targetX = rng.Next(U);
                targetY = rng.Next(V);
            } while (grid[targetX, targetY].color != ' ' || grid[targetX, targetY].state == CellState.robot);
            grid[targetX, targetY].color = 'R';
        }

        // Create target zones for green jewels
        for (int i = 0; i < numGreenJewels; i++)
        {
            int targetX, targetY;
            do { 
                targetX = rng.Next(U);
                targetY = rng.Next(V);
            } while (grid[targetX, targetY].color != ' ' || grid[targetX, targetY].state == CellState.robot);
            grid[targetX, targetY].color = 'G';
        }
        
        // Create target zones for blue jewels
        for (int i = 0; i < numBlueJewels; i++)
        {
            int targetX, targetY;
            do
            {
                targetX = rng.Next(U);
                targetY = rng.Next(V);
            } while (grid[targetX, targetY].color != ' ' || grid[targetX, targetY].state == CellState.robot);
            grid[targetX, targetY].color = 'B';
        }
    }
    
}