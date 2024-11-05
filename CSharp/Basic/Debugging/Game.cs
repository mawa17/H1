namespace BattleshipGP
{
    internal class Game
    {
        enum Board { Ships, Hits }

        static int xc = 4, yc = 3, ships = 3;
        static int players = 2;
        //static int[,] p1Ships = new int[xc, yc];
        //static int[,] p2Ships = new int[xc, yc];
        //static int[,] p1Hits = new int[xc, yc];
        //static int[,] p2Hits = new int[xc, yc];

        static int[,,,] gameArray = new int[players, 2, xc, yc];

        public static void SetupGame()
        {
            //Place ships for each player for each ship
            for (int i = 0; i < players; i++)
            {
                Console.WriteLine($"Player {i + 1}, place your ships.");
                for (int j = 0; j < ships; j++) { PlaceShip(i); }
            }

            StartGame();
        }

        private static void ShowShips(int player)
        {
            for (int x = 0; x < xc; x++)
                for (int y = 0; y < yc; y++)
                    Console.WriteLine($"Coordinate : {x},{y} {gameArray[player, 0, x, y]} ");
        }

        private static void PlaceShip(int player)
        {
            ShowShips(player);
            Console.WriteLine("Place a ship");
            int x, y;
            //TODO Make a f.... method!!!
            do { Console.WriteLine("Put X"); }
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= xc);
            do { Console.WriteLine("Put Y"); }
            while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= yc);
            gameArray[player, 0, x, y] = 1;
            //TODO check if ship already exists on coordinate
        }

        private static void StartGame()
        {
            //TODO Make method to check if remaining ships
            while (true)
            {
                for (int i = 0; i < players; i++)
                {

                    Shoot(i);
                }
            }

        }



        private static void ShowHits(int player)
        {
            for (int x = 0; x < xc; x++)
                for (int y = 0; y < yc; y++)
                    Console.WriteLine($"Coordinate : {x},{y} {gameArray[player, 1, x, y]} ");
        }

        private static void Shoot(int player)
        {
            Console.WriteLine($"Player {player + 1}, fire away!");

            ShowHits(player);
            int x, y;
            //TODO Make a f.... method!!!
            do { Console.WriteLine("Put X"); }
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= xc);
            do { Console.WriteLine("Put Y"); }
            while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= yc);

            for (int i = 0; i < players; i++)
            {
                if (player != i && gameArray[i, (int)Board.Ships, x, y] == 1)
                {
                    //Ship hit
                    Console.WriteLine("You hit a ship!");
                    gameArray[i, (int)Board.Ships, x, y] = 0;
                }
                //Shot is marked on own board
                gameArray[player, (int)Board.Hits, x, y] = 1;
            }
        }
    }
}