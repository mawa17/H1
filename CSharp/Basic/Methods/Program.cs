using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Channels;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args) => Solutions._7.Entry();
    }

    internal static class Solutions
    {
        internal static class _1
        {
            internal static void Entry() => Console.WriteLine(MethodString());
            internal static string MethodString() => "Hello World";
        }
        internal static class _2
        {
            internal static void Entry()
            {
                Console.WriteLine("Write some text");
                string? text = Console.ReadLine();
                Print(text ?? "Text was null");
            }
            internal static void Print(string arg) => Console.WriteLine(arg);
        }
        internal static class _3
        {
            internal static void Entry()
            {
                Console.WriteLine("Write 3 numbers Eg 1 2 3");
                string[] numbers = Console.ReadLine().Split(' ');
                int[] nums = numbers.Select(int.Parse).ToArray();
                Console.WriteLine($"Sum = {Sum(nums)}");
            }
            internal static int Sum(params int[] nums) => nums.Sum();
        }
        internal static class _3a
        {
            internal static void Entry()
            {
                Console.WriteLine("Write 3 numbers Eg 1 2 3");
                string[] numbers = Console.ReadLine().Split(' ');
                int[] nums = numbers.Select(int.Parse).ToArray();
                Console.WriteLine($"Subtract = {Subtract(nums)}");
            }
            internal static int Subtract(params int[] nums) => nums.Aggregate((a, b) => a - b);
        }

        internal static class _3b
        {
            internal static void Entry()
            {
                Console.WriteLine("Write 3 numbers Eg 1 2 3");
                string[] numbers = Console.ReadLine().Split(' ');
                int[] nums = numbers.Select(int.Parse).ToArray();
                Console.WriteLine($"Subtract = {Multiply(nums)}");
            }
            internal static int Multiply(params int[] nums) => nums.Aggregate((a, b) => a * b);
        }

        internal static class _3c
        {
            internal static void Entry()
            {
                Console.WriteLine("Write 3 numbers Eg 1 2 3");
                string[] numbers = Console.ReadLine().Split(' ');
                int[] nums = numbers.Select(int.Parse).ToArray();
                Console.WriteLine($"SubtractDivide = {SubtractDivide(nums[0], nums[1], nums[2])}");
            }
            internal static int SubtractDivide(int num1, int num2, int num3) => (num1 + num2) / num3;
        }

        public static bool InRange(this in byte a, in byte b, in byte c) => a >= b && a <= c;
        internal static class _4
        {
            internal static void Entry()
            {
                Console.Write("Enter your name:");
                string? name = Console.ReadLine();

                Console.Write("Enter your:");
                if (!byte.TryParse(Console.ReadLine(), out byte age))
                {
                    Console.WriteLine($"Age must be between {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.WriteLine(GetNameAgeText(name, age));
            }
            private static string GetNameAgeText([DefaultValue("No Name")] string name, byte age)
            {
                return age.InRange(0, 1) ? name + "Du er nyfødt" :
                        age.InRange(2, 3) ? name + "Du er i dagpleje eller vuggestue" :
                        age.InRange(4, 5) ? name + "Du er i børnehave" :
                        age.InRange(6, 18) ? name + "Du går i skole" : name + "Nu begynder livet at blive alvor";
            }
        }

        internal static class _5
        {
            internal static void Entry()
            {
                Console.Write("Write comma sepreated text Eg Hey, There, World");
                string? text = Console.ReadLine();
                string[] arr = SplitString(text);
                for (int i = 0; i < arr.Length; i++)
                    Console.WriteLine(arr[i]);
            }
            private static string[] SplitString(string text, char splitChar = ',') => text.Split(splitChar);
        }
        internal static class _6
        {
            internal static void Entry()
            {
                GuessTheNumber();
            }
            private static byte GenerateNumber() => (byte)(new Random().Next(1, 25));
            private static void CheckNumber(byte input, byte target)
            {
                if (input > target)
                {
                    Console.WriteLine($"{input} is too high!");
                    return;
                }
                Console.WriteLine($"{input} is too low!");
            }
            private static void GuessTheNumber()
            {
                byte rand = GenerateNumber();
                byte remainingGuesses = 5;

                Console.WriteLine("Guess The number between 1 & 25");
                while (remainingGuesses > 0)
                {
                    Console.Write("Enter your number:");
                    if (!byte.TryParse(Console.ReadLine(), out byte num))
                    {
                        Console.WriteLine($"Number must be in range {byte.MinValue}-{byte.MaxValue}");
                        return;
                    }
                    if (num == rand)
                    {
                        Console.Write("You guessed the number!");
                        return;
                    }
                    CheckNumber(num, rand);
                    remainingGuesses--;
                }
                Console.Write("You ran out of tries!");
            }
        }

        internal static class _7
        {
            internal static void Entry()
            {
                IReadOnlyDictionary<string, Type> solutionsMap = new Dictionary<string, Type>()
                {
                    { "1",  typeof(_1) },
                    { "2",  typeof(_2) },
                    { "3",  typeof(_3) },
                    { "3a", typeof(_3a) },
                    { "3b", typeof(_3b) },
                    { "1c", typeof(_3c) },
                    { "4",  typeof(_4) },
                    { "5.", typeof(_5) },
                    { "6.", typeof(_6) },
                    { "7a", typeof(_7a) },
                    { "7b", typeof(_7b) },
                    { "7c", typeof(_7c) }
                };

                Console.WriteLine("Select a solution to execute: ");
                foreach (var mapping in solutionsMap)
                    Console.WriteLine(mapping.Key);
                string? key = Console.ReadLine()?.ToLower();
                if (String.IsNullOrEmpty(key) || !solutionsMap.ContainsKey(key))
                {
                    Console.WriteLine("Key is empty or solution not defined!");
                    return;
                }
                var mapType = solutionsMap[key];

                MethodInfo method = solutionsMap[key].GetMethod("Entry", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod);
                method.Invoke(null, null);
            }
        }

        internal static class _7a
        {
            internal static void Entry()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Write a tempture: ");
                    if (!short.TryParse(Console.ReadLine(), out short temp))
                    {
                        Console.WriteLine("The input must be a number!");
                        return;
                    }
                    Console.WriteLine("Select (C) for Celsius scale or (F) for fahrenheit");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key != ConsoleKey.C || key != ConsoleKey.F)
                    {
                        Console.WriteLine("Incorrect tempture scale!");
                        return;
                    }
                    if (key == ConsoleKey.C)
                    {
                        Console.WriteLine("Temperatures for Celsius");
                        Console.WriteLine($"Celsius to Fahrenheit {(temp * 9 / 5) + 32}");
                        Console.WriteLine($"Celsius to Kelvin {(temp + 273.15)}");
                        Console.WriteLine($"Celsius to Fahrenheit {(temp * 4 / 5)}");
                        return;
                    }

                    Console.WriteLine("Temperatures for Fahrenheit");
                    Console.WriteLine($"Fahrenheit to Celsius {((temp - 32) * 5 / 9)}");
                    Console.WriteLine($"Fahrenheit to Kelvin {(((temp - 32) * 5 / 9) + 273.15)}");
                    Console.WriteLine($"Fahrenheit to Fahrenheit {((temp - 32) * 4 / 9)}");
                }
            }
        }
        public static string ToHex(this int number) => Convert.ToString(number, 16);
        public static decimal ToDecimal(this int number) => Convert.ToDecimal(number);
        public static string ToBinary(this int number) => Convert.ToString(number, 2);

        internal static class _7b
        {
            internal static void Entry()
            {
                Console.Write("Enter your number:");
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine($"Number must be in range {int.MinValue}-{int.MaxValue}");
                    return;
                }
                Console.WriteLine($"Here is your number {num} in Hex, Binary & Decimal");
                Console.WriteLine($"Num in Hex {num.ToHex()}");
                Console.WriteLine($"Num in Binary {num.ToBinary()}");
                Console.WriteLine($"Num in Decimal {num.ToDecimal()}");
            }
        }

        internal static class _7c
        {
            internal static void Entry()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Write a number");
                    if (!int.TryParse(Console.ReadLine(), out int num))
                    {
                        Console.WriteLine($"Number must be in range {int.MinValue}-{int.MaxValue}");
                        return;
                    }
                    Console.WriteLine("Write some text");
                    string? text = Console.ReadLine();
                }
      
            }
        }
    }
}