using System;
using System.Collections.Generic;

class Program
{

    static void Main()
    {
        World world = new World();
        world.Start();

        Console.WriteLine("\nDEBUG INFO");
        Console.WriteLine($"Red Robot at: ({world.robotRed.X}, {world.robotRed.Y})");
        Console.WriteLine($"Green Robot at: ({world.robotGreen.X}, {world.robotGreen.Y})");
        Console.WriteLine($"Blue Robot at: ({world.robotBlue.X}, {world.robotBlue.Y})");
        
        int redJewelCount = 0, greenJewelCount = 0, blueJewelCount = 0;
        foreach (var jewel in world.jewels)
        {
            if (jewel.Color == 'R') redJewelCount++;
            else if (jewel.Color == 'G') greenJewelCount++;
            else if (jewel.Color == 'B') blueJewelCount++;
        }
        
        Console.WriteLine($"Red Jewels created: {redJewelCount}");
        Console.WriteLine($"Green Jewels created: {greenJewelCount}");
        Console.WriteLine($"Blue Jewels created: {blueJewelCount}");
        Console.WriteLine();

        DrawGrid(world);

        Console.WriteLine("\nLEGEND");
        Console.WriteLine("[ R ] = Robots (UPPERCASE)");
        Console.WriteLine("[ r ] = Jewels (lowercase)");
        Console.WriteLine("{ r } = Target zone with jewel");
        Console.WriteLine("{   } = Empty target zone");
        Console.WriteLine("[   ] = Empty cell");
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    static void DrawGrid(World world)
    {
        Console.WriteLine("Current World State:");
        
        for (int y = 0; y < world.V; y++)
        {
            for (int x = 0; x < world.U; x++)
            {
                string displayString = GetDisplayString(world, x, y);
                
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = GetConsoleColor(world.grid[x, y], displayString);
                Console.Write(displayString);
                Console.ForegroundColor = originalColor;
                
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    
    static string GetDisplayString(World world, int x, int y)
    {
        Cell cell = world.grid[x, y];
        bool isTargetZone = cell.color != ' ';
        
        if (cell.state == CellState.robot)
        {
            char robotChar = ' ';
            if (world.robotRed.X == x && world.robotRed.Y == y)
                robotChar = 'R';
            else if (world.robotGreen.X == x && world.robotGreen.Y == y)
                robotChar = 'G';
            else if (world.robotBlue.X == x && world.robotBlue.Y == y)
                robotChar = 'B';
            
            if (isTargetZone)
                return $"{{{{ {robotChar} }}}}";
            else
                return $"[ {robotChar} ]";
        }
        else if (cell.state == CellState.jewel && cell.LayingJewel != null)
        {
            char jewelChar = char.ToLower(cell.LayingJewel.Color);
            
            if (isTargetZone)
                return $"{{ {jewelChar} }}";
            else
                return $"[ {jewelChar} ]";
        }
        else if (isTargetZone)
        {
            return "{   }";
        }
        
        return "[   ]";
    }
    
    static ConsoleColor GetConsoleColor(Cell cell, string displayString)
    {
        // For target zones, use the cell's color
        if (cell.color != ' ')
        {
            return cell.color switch
            {
                'R' => ConsoleColor.Red,
                'G' => ConsoleColor.Green,
                'B' => ConsoleColor.Blue,
                _ => ConsoleColor.Gray
            };
        }
        
        // For robots and jewels, use the display string
        if (displayString.Contains('R') || displayString.Contains('r'))
            return ConsoleColor.Red;
        else if (displayString.Contains('G') || displayString.Contains('g'))
            return ConsoleColor.Green;
        else if (displayString.Contains('B') || displayString.Contains('b'))
            return ConsoleColor.Blue;
        else
            return ConsoleColor.Gray;
    }
}