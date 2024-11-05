namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameInstance();
            while (!game.IsCompleted)
            {
                
                Console.Write("Your Guess:");
                string? guess = Console.ReadLine();
                if(guess is null || guess.Length < 1)
                {
                    Console.WriteLine("Please enter a letter (Try again)");
                    continue;
                }
                char c = guess[0];
                game.Guess(c);
                Console.WriteLine($"Status:  {game.Status}");
            }
        }
    }


    internal class GameInstance
    {
        private readonly string word = GameHelper.GetRandomWord();
        private List<char> remaning;
        public bool IsCompleted => this.remaning.Count == 0;
        public string Status => GetStatus();
       
        public GameInstance()
        {
            this.remaning = this.word.ToList();
        }
        internal void Guess(char c)
        {
            if(this.IsCompleted)
            {
                Console.WriteLine($"You guessed the word {this.word}");
                return;
            }
            if (!this.word.Contains(c))
            {
                Console.WriteLine("Incorrect");
                return;
            }
            this.remaning.Remove(c);
            Console.WriteLine("Correct!");
        }

        private string GetStatus()
        {
            string status = "";

            foreach (char letter in this.word)
            {
                if (!this.remaning.Contains(letter)) status += letter;
                else status += "_"; 
            }

            return status;
        }

    }
    internal static class GameHelper
    {
        private static string[] GetWords() => File.ReadAllLines("C:\\Users\\marcu\\Desktop\\H1\\Programming\\Hangman\\words.txt");
        internal static string GetRandomWord()
        {
            var words = GetWords();
            var rand = new Random();
            var i = rand.Next(0, words.Length);
            return words[i];
        }
    }
}