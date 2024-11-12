namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRepository.ReadFile();

            Console.Write("Write last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Write age: ");
            if(!byte.TryParse(Console.ReadLine(), out byte age))
            {
                Console.WriteLine("Failed to parse age");
                return;
            }

            Console.Write("Write email: ");
            string email = Console.ReadLine();

            RegisteredUsers user = new(lastName, age, email);
            var ex = user.Validate();
            if(ex is not null) Console.WriteLine(ex.Message);
            UserRepository.Add(user);
            UserRepository.WriteFile();
        }
    }
}
