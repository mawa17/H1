using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public static class SoundHelper
    {
        private static async Task PlaySoundAsync(string filePath)
        {
            await Task.Run(() =>
            {
                using (var soundPlayer = new SoundPlayer(filePath))
                {
                    soundPlayer.PlaySync();
                }
            });
        }
        public static async Task PlaySoundAsync(enmAnimals animal)
        {
            switch (animal)
            {
                case enmAnimals.Dog:
                    await PlaySoundAsync("C:\\Users\\marcu\\Desktop\\H1\\CSharp\\OOP\\Polymorphism\\dog.wav");
                    break;
                case enmAnimals.Cat:
                    await PlaySoundAsync("C:\\Users\\marcu\\Desktop\\H1\\CSharp\\OOP\\Polymorphism\\cat.wav");
                    break;
                case enmAnimals.Sheep:
                    await PlaySoundAsync("C:\\Users\\marcu\\Desktop\\H1\\CSharp\\OOP\\Polymorphism\\sheep.wav");
                    break;
            }
        }
    }
    public abstract class Animals
    {
        public abstract Task<string> MakeSoundAsync();
        public string Name { get; init; }
        protected Animals(in string name) => this.Name = name;
    }

    public class Dog(in string name) : Animals(name)
    {
        public override async Task<string> MakeSoundAsync()
        {
            await SoundHelper.PlaySoundAsync(enmAnimals.Dog);
            return "Vow";
        }
    }
    public class Cat(in string name) : Animals(name)
    {
        public override async Task<string> MakeSoundAsync()
        {
            await SoundHelper.PlaySoundAsync(enmAnimals.Cat);
            return "Meau";
        }
    }
    public class Sheep(in string name) : Animals(name)
    {
        public override async Task<string> MakeSoundAsync()
        {
            await SoundHelper.PlaySoundAsync(enmAnimals.Sheep);
            return "Baaaah";
        }
    }
    public enum enmAnimals
    {
        Dog = 1,
        Cat = 2,
        Sheep = 3,
    }
    public static class AnimalFactory
    {
        public static Animals? CreateAnimal(in string name, in enmAnimals animal) => animal switch
        {
            enmAnimals.Dog => new Dog(name),
            enmAnimals.Cat => new Cat(name),
            enmAnimals.Sheep => new Sheep(name),
            _ => null,
        };
        public static Animals? CreateAnimal(in enmAnimals animal) => animal switch
        {
            enmAnimals.Dog => new Dog("Frida"),
            enmAnimals.Cat => new Cat("Luna"),
            enmAnimals.Sheep => new Sheep("Ella"),
            _ => null,
        };
    }
}
