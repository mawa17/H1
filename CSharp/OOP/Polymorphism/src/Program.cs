using System.Reflection.Metadata;

namespace src
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Animals? dog = AnimalFactory.CreateAnimal("bob", enmAnimals.Dog);
            Animals? cat = AnimalFactory.CreateAnimal("bo", enmAnimals.Cat);
            Animals? sheep = AnimalFactory.CreateAnimal("bobby", enmAnimals.Sheep);
            Console.WriteLine($"The dog {dog?.Name} says : {await dog?.MakeSoundAsync()}");
            Console.WriteLine($"The cat {cat?.Name} says : {await cat?.MakeSoundAsync()}");
            Console.WriteLine($"The sheep {sheep?.Name} says : {await sheep?.MakeSoundAsync()}");
        }
    }
}
