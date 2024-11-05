using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;

namespace AssignmentBooklet
{
    internal class Program
    {
        static void Main(string[] args) => Solutions._7_4.Entry();
    }



    internal static class Solutions
    {
        internal static class _1_1
        {
            internal static void Entry()
            {
                Console.Write("Write a Fahrenheit degree: ");
                if (!short.TryParse(Console.ReadLine(), out short fahrenheit))
                {
                    Console.WriteLine($"The number entered dosen't fit in range [{short.MinValue}-{short.MaxValue}]");
                    return;
                }
                short celsius = CalculateCelsius(fahrenheit);
                Console.WriteLine($"{fahrenheit} Fahrenheit in Celsius = {celsius}");
            }
            private static short CalculateCelsius(short fahrenheit) => (short)((fahrenheit - 32) * 5 / 9);
        }
        internal static class _1_2
        {
            internal static void Entry()
            {
                Console.Write("Write a Celsius degree: ");
                if (!short.TryParse(Console.ReadLine(), out short celsius))
                {
                    Console.WriteLine($"The number entered dosen't fit in range [{short.MinValue}-{short.MaxValue}]");
                    return;
                }
                PrintResult(celsius);
            }
            private static void PrintResult(short celsius)
            {
                Console.WriteLine($"{celsius} Celsius is also equivalent to");
                Console.WriteLine($"{((celsius * 9 / 5) + 32)} Fahrenheit");
                Console.WriteLine($"{(celsius + 273.15)} Kelvin");
                Console.WriteLine($"{(celsius * 0.8)} Réaumur");
            }


        }
        internal static class _1_3
        {
            internal static void Entry()
            {
                Console.WriteLine("Write current exchange rate for EUR to DKK");
                if (!float.TryParse(Console.ReadLine(), out float rate))
                {
                    Console.WriteLine("exchange rate must be a decimal!");
                    return;
                }

                Console.WriteLine("Write EUR currency amount");
                if (!float.TryParse(Console.ReadLine(), out float amount))
                {
                    Console.WriteLine("exchange rate must be a decimal!");
                    return;
                }

                Console.WriteLine($"For {amount} EUR you can get {amount * rate / 100} DKK");
            }
        }
        internal static class _1_4
        {
            internal static void Entry()
            {
                Console.WriteLine("Enter Turnover");
                if (!float.TryParse(Console.ReadLine(), out float turnover))
                {
                    Console.WriteLine("turnover must be a number!");
                    return;
                }

                Console.WriteLine("Write Variable Expenses");
                if (!float.TryParse(Console.ReadLine(), out float variableExpenses))
                {
                    Console.WriteLine("variableExpenses must be a number!");
                    return;
                }

                Console.WriteLine("Write Fixed Expenses");
                if (!float.TryParse(Console.ReadLine(), out float fixedExpenses))
                {
                    Console.WriteLine("fixedExpenses must be a number!");
                    return;
                }
                float coverage = turnover - variableExpenses;
                float surplus = coverage - fixedExpenses;

                Console.WriteLine($"With a Turnover of {turnover}");
                Console.WriteLine($"With variableExpenses of {variableExpenses}");
                Console.WriteLine($"With fixedExpenses of {fixedExpenses}");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                Console.WriteLine($"With a coverage of {coverage}");
                Console.WriteLine($"That leaves a surplus of {surplus}");

            }
        }
        internal static class _1_5
        {
            internal static void Entry()
            {
                Console.WriteLine("Enter Turnover");
                if (!float.TryParse(Console.ReadLine(), out float turnover))
                {
                    Console.WriteLine("turnover must be a number!");
                    return;
                }

                Console.WriteLine("Write Variable Expenses");
                if (!float.TryParse(Console.ReadLine(), out float variableExpenses))
                {
                    Console.WriteLine("variableExpenses must be a number!");
                    return;
                }

                Console.WriteLine("Write Fixed Expenses");
                if (!float.TryParse(Console.ReadLine(), out float fixedExpenses))
                {
                    Console.WriteLine("fixedExpenses must be a number!");
                    return;
                }
                float coverage = turnover - variableExpenses;
                float surplus = coverage - fixedExpenses;
                float coverageDegree = (coverage / turnover) * 100;
                float profitMargin = (surplus / turnover);

                Console.WriteLine($"With a Turnover of {turnover}");
                Console.WriteLine($"With variableExpenses of {variableExpenses}");
                Console.WriteLine($"With fixedExpenses of {fixedExpenses}");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                Console.WriteLine($"With a coverage of {coverage}");
                Console.WriteLine($"That leaves a surplus of {surplus}");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                Console.WriteLine($"coverageDegree: {coverageDegree}");
                Console.WriteLine($"profitMargin: {profitMargin}");
            }
        }

        public static bool InRange(this in byte a, in byte b, in byte c) => a >= b && a <= c;
        public static class _2_1
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
                Console.WriteLine(GetAgeText(age));
            }
            private static string GetAgeText(byte age)
            {
                return age.InRange(1, 1) ? "Du er lige født" :
                        age.InRange(2, 5) ? "Du kan begynde i børnehave" :
                        age.InRange(6, 16) ? "Du går i skole" : "Nu begynder alvoren";
            }
        }
        public static class _2_2
        {
            internal static void Entry()
            {
                Console.Write("Enter your name:");
                string? name = Console.ReadLine();

                Console.Write("Enter your age:");
                if (!byte.TryParse(Console.ReadLine(), out byte age))
                {
                    Console.WriteLine($"Age must be between {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                ConsoleColor color = GetAgeColor(age);
                Console.ForegroundColor = color;
                Console.WriteLine($"{color}");

            }
            private static ConsoleColor GetAgeColor(byte age)
            {
                return age.InRange(1, 1) ? ConsoleColor.Red :
                        age.InRange(2, 5) ? ConsoleColor.Yellow :
                        age.InRange(6, 16) ? ConsoleColor.Green : ConsoleColor.Blue;
            }
        }
        public static class _2_3
        {
            internal static void Entry()
            {
                Console.Write("Enter your age:");
                if (!byte.TryParse(Console.ReadLine(), out byte age))
                {
                    Console.WriteLine($"Age must be between {byte.MinValue}-{byte.MaxValue}");
                    return;
                }

                Console.Write("Enter your gender:");
                string? gender = Console.ReadLine();
                #region Junk Logic
                if (age < 18)
                {
                    if (gender == "Male")
                    {
                        Console.WriteLine("You're a male under 18 years");
                    }
                    else
                    {
                        Console.WriteLine("You're a woman under 18 years");
                    }
                }
                else
                {
                    if (gender == "Male")
                    {
                        Console.WriteLine("You're a male over or equal 18 years");
                    }
                    else
                    {
                        Console.WriteLine("You're a woman over or equal 18 years");
                    }
                }
                #endregion

                Console.ForegroundColor = GetAgeColor(age);
                Console.WriteLine("Alder Karakter");
            }
            private static ConsoleColor GetAgeColor(byte age)
            {
                return age.InRange(1, 4) ? ConsoleColor.Red :
                        age.InRange(5, 9) ? ConsoleColor.Yellow : ConsoleColor.Green;
            }
        }

        public static class _3_1
        {
            internal static void Entry()
            {
                Console.Write("Enter number for a weekday Monday = 1, Tuesday = 2, Wednesday = 3 etc");
                if (!byte.TryParse(Console.ReadLine(), out byte date))
                {
                    Console.WriteLine($"Age must be between {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                switch (date)
                {
                    case 1: Console.WriteLine("Today it is Monday"); break;
                    case 2: Console.WriteLine("Today it is Tuesday"); break;
                    case 3: Console.WriteLine("Today it is Wednesday"); break;
                    case 4: Console.WriteLine("Today it is Thursday"); break;
                    case 5: Console.WriteLine("Today it is Friday"); break;
                    case 6: Console.WriteLine("Today it is Saturday"); break;
                    case 7: Console.WriteLine("Today it is Sunday"); break;
                }
            }
        }

        public static class _3_2
        {
            internal static void Entry()
            {
                Console.Write("Write a Celsius temperature");
                if (!int.TryParse(Console.ReadLine(), out int temp))
                {
                    Console.WriteLine($"Temperature must be between {int.MinValue}-{int.MaxValue}");
                    return;
                }
                Console.Write("Select new temperature scale\n\r(F) for Fahrenheit\n\r(K) for Kelvin\n\r(R) for Réaumur");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F:
                        Console.WriteLine($"Celsius {temp} equals {(temp * (9 / 5) + 32)} Fahrenheit");
                        break;
                    case ConsoleKey.K:
                        Console.WriteLine($"Celsius {temp} equals {(temp + 273.15)} Kelvin");
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine($"Celsius {temp} equals {(temp * 0.8)} Réaumur");
                        break;
                    default:
                        Console.WriteLine("The entered temperature scale is invalid");
                        break;
                }

            }
        }

        public static class _4
        {
            internal static void Entry()
            {
                Console.WriteLine("Write the table to display");
                if (!ushort.TryParse(Console.ReadLine(), out ushort table))
                {
                    Console.WriteLine($"The number must in range {ushort.MinValue}-{ushort.MaxValue}");
                    return;
                }
                Console.WriteLine("How many rows to display?");
                if (!ushort.TryParse(Console.ReadLine(), out ushort rows))
                {
                    Console.WriteLine($"The number must in range {ushort.MinValue}-{ushort.MaxValue}");
                    return;
                }
                Console.WriteLine($"Displaying {rows} for table {table}");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                for (int i = 1; i <= rows; i++) Console.WriteLine($"{i} x {table} = {i * table}");
            }
        }

        public static class _4_1
        {
            internal static void Entry()
            {
                Console.WriteLine("Enter X coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte x))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.WriteLine("Enter Y coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte y))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.SetCursorPosition(x, y);
                Console.WriteLine("".PadRight(10, '─'));
            }
        }

        public static class _4_2
        {
            internal static void Entry()
            {
                Console.WriteLine("Enter X coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte x))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.WriteLine("Enter Y coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte y))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.SetCursorPosition(x, y);
                Console.WriteLine("".PadRight(10, '─'));
                Console.SetCursorPosition(x, y + 4);
                Console.WriteLine("".PadRight(10, '─'));
            }
        }
        public static class _4_3
        {
            internal static void Entry()
            {

                Console.WriteLine("Enter X coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte x))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.WriteLine("Enter Y coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte y))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }

                Console.SetCursorPosition(x, y);
                Console.WriteLine("".PadRight(10, '─') + "");
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("".PadRight(x, ' ') + "│".PadRight(10, ' ') + "│");
                Console.WriteLine("".PadRight(x, ' ') + "".PadRight(10, '─') + "");


            }
        }
        public static class _4_4
        {
            internal static void Entry()
            {

                Console.WriteLine("Enter X coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte x))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                Console.WriteLine("Enter Y coordinate");
                if (!byte.TryParse(Console.ReadLine(), out byte y))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }

                Console.SetCursorPosition(x, y);
                Console.WriteLine("┌".PadRight(10, '─') + "┐");
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("".PadRight(x, ' ') + "│".PadRight(10, ' ') + "│");
                Console.WriteLine("".PadRight(x, ' ') + "└".PadRight(10, '─') + "┘");

            }
        }

        public static class _4_5
        {
            internal static void Entry()
            {
                List<string> linesRead = new();
                string? currentLine = String.Empty;
                Console.WriteLine("Write \"slut\" to exit the loop");
                Console.WriteLine("Write something");
                do
                {
                    currentLine = Console.ReadLine();
                    linesRead.Add(currentLine);
                }
                while (currentLine != "slut");
                Console.Clear();
                Console.WriteLine("Here is the complete history of all lines written ENJOY");
                Console.WriteLine("".PadRight(Console.WindowWidth, '='));
                foreach (var line in linesRead) Console.WriteLine(line);
            }
        }

        public static class _5_1
        {
            internal static void Entry()
            {
                Console.WriteLine($"Table of Celsius from 10-100 degrees in Fahrenheit");
                for (int i = 10; i <= 100; i++)
                {
                    float f = (i * 9 / 5) + 32;
                    Console.WriteLine($"{i} Celsius = {f} Fahrenheit");
                }
            }
        }
        public static class _5_2
        {
            internal static void Entry()
            {
                Console.WriteLine($"Table of Celsius from 10-100 degrees in Fahrenheit");
                for (int i = 10; i <= 100; i += 10)
                {
                    float f = (i * 9 / 5) + 32;
                    Console.WriteLine($"{i} Celsius = {f} Fahrenheit");
                }
            }
        }

        public static class _5_3
        {
            internal static void Entry()
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Text with color");
                }
            }
        }

        public static class _6_1
        {
            internal static void Entry()
            {
                Console.WriteLine("Write a radius for the circle");
                if (!byte.TryParse(Console.ReadLine(), out byte radius))
                {
                    Console.WriteLine($"The number must in range {byte.MinValue}-{byte.MaxValue}");
                    return;
                }
                float formula = (float)(Math.PI * 2) * radius;
                Console.WriteLine($"The circumference of the circle with radius of {radius} is {formula}");
            }
        }

        public static class _7_1
        {
            internal static void Entry()
            {
                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
                int blankCount = text.Count(x => x == ' ');
                Console.WriteLine($"In the following string: {text}");
                Console.WriteLine($"There are {blankCount} spaces");
            }
        }

        public static class _7_2
        {
            internal static void Entry()
            {
                string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
                string newText = text.Replace(' ', '\n');
                Console.Write(newText);
            }
        }

        public static class _7_3
        {
            internal static void Entry()
            {
                string name = "hans hansen";
                Console.WriteLine(FirstToUpper(name));
            }

            static string FirstToUpper(string input)
            {
                string[] words = input.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                    }
                }

                return string.Join(" ", words);
            }
        }

        public static class _7_4
        {
            internal static void Entry()
            {
                Console.WriteLine("Write some names with spaces (Eg hans hansen)");
                string? input = Console.ReadLine();
                Console.WriteLine(FirstToUpper(input));
            }

            static string FirstToUpper(string input)
            {
                string[] words = input.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                    }
                }

                return string.Join(" ", words);
            }
        }

        public static class _7_5
        {
            internal static void Entry() => _7_4.Entry();
        }

        public static class _8_1
        {
            internal static void Entry()
            {
                string[] months = new[]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
            }
        }

        public static class _8_2
        {
            internal static void Entry()
            {
                string[] months = new[]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
                var e = months.Where(x => x.Contains('a'));
                Console.WriteLine("Here is all the months that contains with A");
                foreach (var month in e)
                {
                    Console.WriteLine(month);
                }

            }
        }

        public static class _8_3
        {
            internal static void Entry()
            {
                string[] months = new[]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
                var e = months.Where(x => x.Length > 4).OrderBy(y => y);
                Console.WriteLine("Here is all the months longer then 4 chars & ordered");
                foreach (var month in e)
                {
                    Console.WriteLine(month);
                }

            }
        }

        public static class _8_4
        {
            internal static void Entry()
            {

            }
        }
    }
}
