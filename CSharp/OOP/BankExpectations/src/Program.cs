using System.Security.Principal;

namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountOwner accountOwner = new() { SurName = "Marucs", LastName = "W" };
            Account account = new(accountOwner);
            try
            {

                Console.Write("Enter amount to deposit: ");
                if (!uint.TryParse(Console.ReadLine(), out var deposit))
                {
                    string err = $"The given input must match range {uint.MinValue}-{uint.MaxValue}";
                    Console.WriteLine(err);
                    throw new FormatException(err);
                }
                if (deposit < 0) throw new ArgumentException("deposit value must me > 0");
                string result = account.Deposit(deposit);
                Console.WriteLine(result);

                Console.Write("Enter amount to withdraw: ");
                if (!uint.TryParse(Console.ReadLine(), out var withdraw))
                {
                    string err = $"The given input must match range {uint.MinValue}-{uint.MaxValue}";
                    Console.WriteLine(err);
                    throw new FormatException(err);
                }
                if (withdraw < 0) throw new ArgumentException("deposit value must me > 0");
                if (!account.TryWithdraw(withdraw, out string withdrawResult))
                {
                    Console.WriteLine(withdrawResult);
                    throw new InvalidOperationException(withdrawResult);
                }

                Console.WriteLine($"Accont balance for account: {account.accountOwner.FullName} is =  {account.Balance}");
            }
            catch (FormatException ex) /*Input given didnt fit in uint*/
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex) /*Input given < 0*/
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex) /*Failed to Withdraw*/
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("A generic error happend!");
            }
            finally
            {
                Console.WriteLine($"Accont balance for account: {account.accountOwner.FullName} is = {account.Balance}");
            }
        }
    }
}
