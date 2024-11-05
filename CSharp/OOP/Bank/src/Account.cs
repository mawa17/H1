namespace src
{
    public abstract class Person
    {
        public required string SurName { get; init; }
        public required string LastName { get; init; }
        public string FullName => $"{this.SurName} {this.LastName}";
    }
    public sealed class AccountOwner : Person
    {
        public uint ClientId { get; }
        public AccountOwner()
        {
            this.ClientId = (uint)new Random().Next(0, 999999);
        }
    }
    public sealed class Account
    {
        public uint Balance { get; private set; }
        public AccountOwner accountOwner { get; private set; }
        public Account(in AccountOwner owner, uint startBalance = 100)
        {
            this.Balance = Math.Max(startBalance, 100);
            this.accountOwner = owner;
        }
        public string Deposit(uint amount)
        {
            this.Balance += amount;
            return $"Hello {this.accountOwner.FullName}\n{amount} has been deposited into your account\nNow your balance has increeced to: {this.Balance}\n\r";
        }
        public bool TryWithdraw(uint amount, out string result)
        {
            result = string.Empty;
            if(this.Balance < amount)
            {
                result = $"Hello {this.accountOwner.FullName}\nYour account Balance: {this.Balance} is too low to Withdraw: {amount}\n\r";
                return false;
            }
            this.Balance -= amount;
            result = $"Hello {this.accountOwner.FullName}\n{amount} has been withdrawed from your account\nNow your balance has decressed to: {this.Balance}\n\r";
            return true;

        }
    }
}