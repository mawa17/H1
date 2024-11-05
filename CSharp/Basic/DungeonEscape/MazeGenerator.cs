using System;
using static DungeonEscape.MazeHelper;

namespace DungeonEscape
{
    public static class MazeHelper
    {
        private static Random rnd = new Random();
        public static int GetRandom(Range range) => rnd.Next(range.Start.Value, range.End.Value);
    }
    public sealed class MazeGenerator : IMazeGenerator
    {
        private int[,]? _maze;
        public int[,] Maze
        {
            get
            {
                if (_maze is null) GenerateMaze();
                return _maze!;
            }
        }
        public enum RoomType
        {
            Empty = 0,
            Key = 1,
            Exit = 2,
            Trap = 3,
        }
        public void GenerateMaze(byte size = 5, byte maxTraps = 5)
        {
            if (size < 3) throw new ArgumentOutOfRangeException(nameof(size), "Maze size must be at least 3.");

            _maze = new int[size, size];
            maxTraps = (byte)Math.Clamp(maxTraps, 0, Math.Pow(size, 2) - 3);
            byte trapsPlaced = 0;

            int keyX = GetRandom(new(0, size));
            int keyY = GetRandom(new(0, size));
            _maze[keyX, keyY] = (int)RoomType.Key;

            int exitX, exitY;
            do
            {
                exitX = GetRandom(new(0, size));
                exitY = GetRandom(new(0, size));
            } while (exitX == keyX && exitY == keyY);
            _maze[exitX, exitY] = (int)RoomType.Exit;

            while (trapsPlaced < maxTraps)
            {
                int trapX = GetRandom(new(0, size));
                int trapY = GetRandom(new(0, size));
                if (_maze[trapX, trapY] != (int)RoomType.Empty) continue;
                _maze[trapX, trapY] = (int)RoomType.Trap;
                trapsPlaced++;
            }
        }
    }
}