using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace src
{
    public sealed record RegisteredUsers : IComparable<RegisteredUsers>
    {
        public string LastName { get; init; }
        public byte Age { get; init; }
        public string Email { get; init; }

        public RegisteredUsers(in string lastName, in byte age, in string email)
        {
            this.LastName = lastName;
            this.Age = age;
            this.Email = email;
        }
        public Exception? Validate()
        {
            try
            {
                if (String.IsNullOrEmpty(this.LastName)) throw new InvalidNameException("Name cannot be null or empty!");
                if (!Regex.IsMatch(this.Email, "@.*\\.")) throw new InvalidEmailException("Email must contain @ and .");
                if (this.Age is < 18 or > 50) throw new InvalidAgeException("Age must be between 18-50!");
            
            }
            catch (InvalidAgeException ex) when (this.LastName == "Niels Olesen")
            {
                return ex;
            }
            catch (InvalidNameException ex)
            {
                return ex;
            }
            catch (InvalidEmailException ex)
            {
                return ex;
            }
            return null;
        }
        public override string ToString() => $"{this.LastName}, {this.Age}, {this.Email}";

        public int CompareTo(RegisteredUsers? other) => String.Compare(other?.LastName, this.LastName, StringComparison.Ordinal);
    }
    public static class UserRepository
    {
        private static List<RegisteredUsers> _users = new();
        public static IReadOnlyList<RegisteredUsers> SortedUsers => _users;
        private static string _filePath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Files", "Users.txt");
        private static RegisteredUsers? ParseUser(string line)
        {
            try
            {
                string[] data = line.Split(',');
                string lastName = data[0].Trim();
                byte age = Convert.ToByte(data[1].Trim()); /*Will trigger out catch if failed*/
                string email = data[2].Trim();
                return new RegisteredUsers(lastName, age, email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse line: {line} ({ex.Message})");
                return null;
            }
        }
        public static void Add(in RegisteredUsers user)
        {
            _users.Add(user);
            _users.Sort();
        }
        public static void ReadFile()
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            using (StreamReader reader = new StreamReader(fs))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    RegisteredUsers? user = ParseUser(line);
                    if (user is null) continue;
                    _users.Add(user);
                }
            }
            _users.Sort();
        }
        public static void WriteFile()
        {
            using (StreamWriter writer = new(_filePath, append: true))
            {
                foreach (RegisteredUsers user in _users)
                    writer.WriteLine(user.ToString());
            }
        } 
    }
}
