using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace src
{
    public sealed record User
    {
        public string LastName { get; init; }
        public byte Age { get; init; }
        public string Email { get; init; }

        public User(in string lastName, in byte age, in string email)
        {
            if (String.IsNullOrEmpty(lastName)) throw new InvalidNameException("Name cannot be null or empty!");
            if (age is < 18 or > 50) throw new InvalidAgeException("Age must be between 18-50!");
            if (!Regex.IsMatch(email, "@.*\\.")) throw new InvalidEmailException("Email must contain @ and .");
            this.LastName = lastName;
            this.Age = age;
            this.Email = email;
        }
        public override string ToString() => $"{this.LastName}, {this.Age}, {this.Email}";
    }
    public static class UserRepository
    {
        private static List<User> _users = new List<User>();
        public static IReadOnlyList<User> Users => _users;
        private static string _filePath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Files", "Users.txt");
        private static User? ParseUser(string line)
        {
            try
            {
                string[] data = line.Split(',');
                string lastName = data[0].Trim();
                byte age = Convert.ToByte(data[1].Trim()); /*Will trigger out catch if failed*/
                string email = data[2].Trim();
                return new User(lastName, age, email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse line: {line} ({ex.Message})");
                return null;
            }
        }
        public static void Add(in User user) => _users.Add(user);
        public static void ReadFile()
        {
            using (FileStream fs = File.Create(_filePath))
            using (StreamReader reader = new StreamReader(fs))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    User? user = ParseUser(line);
                    if (user is null) continue;
                    _users.Add(user);
                }
            }
        }
        public static void WriteFile()
        {
            using (StreamWriter writer = new(_filePath, append: true))
            {
                foreach (User user in _users)
                    writer.WriteLine(user.ToString());
            }
        } 
    }
}
