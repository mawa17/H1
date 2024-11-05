using System;

namespace DungeonEscape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey loopKey = ConsoleKey.None;
            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.CursorVisible = false;
                
                Console.WriteLine("Welcome to DungeonEscape!");
                Console.WriteLine("Enter map grid size (3-9)");
                Console.Write("Grid size:");
                char input = Console.ReadKey().KeyChar;
                if(!byte.TryParse(Char.ToString(input), out byte gridSize) || gridSize < 3 || gridSize > 9)
                {
                    Console.WriteLine("The grid size must be between 3-9");
                    return;
                }
                Console.WriteLine("\n\rEnter the quantity of traps");
                Console.Write("Total traps:");
                //Max grid size can be 9 so 9^2 = 81 so a byte is enough
                if (!byte.TryParse(Console.ReadLine(), out byte traps))
                {
                    Console.WriteLine($"Please keep the quantity of traps within ({byte.MinValue}-{byte.MaxValue})");
                    return;
                }
                

                var mazeGenerator = new MazeGenerator();
                mazeGenerator.GenerateMaze(gridSize, traps);

                var playerNav = new PlayerNavigator(mazeGenerator);
                playerNav.SpawnPlayer();
                ConsoleKey key;
                do
                {
                    Console.Clear();

                    MazeDrawer.Draw(playerNav.PlayerX, playerNav.PlayerY, mazeGenerator.Maze, playerNav.VisitedRooms);

                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow: playerNav.NavigateUp(); break;
                        case ConsoleKey.DownArrow: playerNav.NavigateDown(); break;
                        case ConsoleKey.LeftArrow: playerNav.NavigateLeft(); break;
                        case ConsoleKey.RightArrow: playerNav.NavigateRight(); break;
                    }
                }
                while (key != ConsoleKey.Escape && !playerNav.IsGameOver);
                Console.Clear();
                Console.ResetColor();
                MazeDrawer.Draw(playerNav.PlayerX, playerNav.PlayerY, mazeGenerator.Maze, playerNav.VisitedRooms, true);
                Console.WriteLine(playerNav.GameOverMessage);
                Console.WriteLine("Play again? press enter");
                loopKey = Console.ReadKey(true).Key;
            }
            while (loopKey == ConsoleKey.Enter);
        }
    }
}
