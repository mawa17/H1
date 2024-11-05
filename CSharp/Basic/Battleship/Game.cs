

using System.Numerics;

namespace BattleshipGP
{
    internal class Game
    {
        static int xc = 4, yc = 3, ships = 3, p = 2;
        //static int[,] p1Ships = new int[xc, yc];
        //static int[,] p2Ships = new int[xc, yc];
        //static int[,] p1Hits = new int[xc, yc];
        //static int[,] p2Hits = new int[xc, yc];

        static int[,,] gameArray = new int[p * 2, xc, yc];

        public static void SetupGame()
        {
            //Place ships for each player for each ship
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine($"Player {i + 1}, place your ships.");
                for (int j = 0; j < ships; j++) { PlaceShip(i); }
            }

            StartGame();
        }

        private static void StartGame()
        {
            for (int i = 0; i < p; i++)
            {
                Shoot(i);
            }
        }

        private static void Shoot(int i)
        {
            int x, y;
            //TODO Make a f.... method!!!
            do { Console.WriteLine("Put X"); }
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= xc);
            do { Console.WriteLine("Put Y"); }
            while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= yc);
        }

        private static void ShowShips(int player)
        {
            for (int x = 0; x < xc; x++)
                for (int y = 0; y < yc; y++)
                    Console.WriteLine($"Coordinate : {x},{y} {gameArray[player, x, y]} ");
        }

        static void PlaceShip(int player)
        {
            ShowShips(player);
            Console.WriteLine("Place a ship");
            int x, y;
            //TODO Make a f.... method!!!
            do { Console.WriteLine("Put X"); }
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= xc);
            do { Console.WriteLine("Put Y"); }
            while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= yc);
            gameArray[player, x, y] = 1;
            //TODO check if ship already exists on coordinate
        }
    }
}