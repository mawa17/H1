namespace CLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string word = await lib.WebScraper.YankDatRandWord();
            Console.WriteLine(word);
        }
    }
}
