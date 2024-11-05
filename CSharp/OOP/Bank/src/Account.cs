using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public sealed class Account
    {
        public AccountOwner AccountOwner { get; }
        public uint Balance { get; private set; }
        public Account(in string surname, in string lastname, uint startBalance = 100)
        {
            this.Balance = Math.Max(startBalance, 100);
            this.AccountOwner = new() { SurName = surname, LastName = lastname };
        }
        public string Deposit(uint amount)
        {
            this.Balance += amount;
            return $"Hello {this.AccountOwner.FullName}\n{amount} has been deposited into your account\nNow your balance has increeced to: {this.Balance}\n\r";
        }
        public bool TryWithdraw(uint amount, out string result)
        {
            result = string.Empty;
            if(this.Balance < amount)
            {
                result = $"Hello {this.AccountOwner.FullName}\nYour account Balance: {this.Balance} is too low to Withdraw: {amount}\n\r";
                return false;
            }
            this.Balance -= amount;
            result = $"Hello {this.AccountOwner.FullName}\n{amount} has been withdrawed from your account\nNow your balance has decressed to: {this.Balance}\n\r";
            return true;

        }
    }
}
