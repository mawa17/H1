namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountOwner accountOwner = new() { SurName = "Marucs", LastName = "W" };
            Account account = new(accountOwner);
            Console.WriteLine($"Hello {account.accountOwner.FullName} your account is now created");
            string result = account.Deposit(1234);
            Console.WriteLine(result);
            if(!account.TryWithdraw(99999999, out string withdrawResult1)) Console.WriteLine(withdrawResult1);
            _ = account.TryWithdraw(1000, out string withdrawResult2);
            Console.WriteLine(withdrawResult2);



        }
    }
}
