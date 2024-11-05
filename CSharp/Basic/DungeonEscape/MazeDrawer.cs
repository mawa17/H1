using System;
using static DungeonEscape.MazeGenerator;

namespace DungeonEscape
{
    /// <summary>
    /// Can visualize a render of a 2d <see cref="int[,]"/> array
    /// </summary>
    public static class MazeDrawer
    {
        /// <summary>
        /// Draws a 2d <see cref="int[,]"/> array to visualize a maze
        /// </summary>
        /// <param name="playerX">The current player X position</param>
        /// <param name="playerY">The current player X position</param>
        /// <param name="maze">The 2d <see cref="int[,]"/> array that defines the maze</param>
        /// <param name="visitedRooms">The 2d <see cref="int[,]"/> array that defines where the player has been</param>
        /// <param name="showMap">Toggles the full exposed maze</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static void Draw(int playerX, int playerY, in int[,] maze, in int[,] visitedRooms, bool showMap = false)
        {
            if (maze.Length != visitedRooms.Length) throw new IndexOutOfRangeException("MazeDrawer.Draw; maze & visitedRooms lengths dosen't match!");
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    RoomType room = (RoomType)maze[x, y];
                    bool hasVisited = visitedRooms[x, y] == 1;

                    if(hasVisited || showMap)
                    {
                        if (room == RoomType.Exit)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("E\t");
                            continue;
                        }
                        else if (room == RoomType.Key)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("K\t");
                            continue;
                        }
                        else if (room == RoomType.Trap)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("T\t");
                            continue;
                        }
                    }
                    if(x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("P\t");
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("X\t");
                }
                Console.WriteLine();
            }
        }
    }
}