// C# Alias Examples
using static System.Console;
using c = System.Console;

namespace BasicProgrammingDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsCorrect = false;
            while(!IsCorrect)
            {
                Console.Write("Write your number:");

                if (!byte.TryParse(Console.ReadLine(), out byte num))
                {
                    Console.Write($"Input value must be bewteen {byte.MinValue} & {byte.MaxValue}");
                }
                IsCorrect = GuessNumber(num, 0, 10);
            }
            Console.Write($"Congratulations you guessed the number!");
        }

        //camelCasing (Variables)
        //PascalCasing (Namespace, Class, Methods...)
        //lowercase (...)
        //UPPERCASE (Constants)
        //AccessModifier - Static/NA.? - ReturnType - MethodName
        private static void AreYouGaming()
        {
            Console.WriteLine("Gamer du?");
            ConsoleKey inputKey = Console.ReadKey(true).Key;
            switch (inputKey)
            {
                case ConsoleKey.J:
                case ConsoleKey.Y:
                    string? gamerTag = WhatIsYourGamerTag();
                    ShowOutput(gamerTag);
                    break;
                default:
                    Console.WriteLine("Ok bye bye");
                    break;
            }
        }
        private static string? WhatIsYourGamerTag()
        {
            Console.WriteLine("What is your gamertag?");
            string? gamerTag = Console.ReadLine();
            return gamerTag;
        }

        private static void ShowOutput(string? gamerTag) => Console.WriteLine($"Hello, {(!String.IsNullOrEmpty(gamerTag) ? gamerTag : "Unkown")}");
    

        private static bool GuessNumber(byte number, byte minNum, byte maxNum)
        {
            Random rnd = new Random();
            byte rndNum = (byte)rnd.Next(minNum, maxNum);
            if (number < rndNum)
            {
                Console.WriteLine($"Number: {number} Too Low!");
                return false;
            }
            else if (number > rndNum)
            {
                Console.WriteLine($"Number: {number} Too High!");
                return false;
            }
            return number == rndNum;
        }
    }
}