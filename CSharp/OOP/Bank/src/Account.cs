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
            this.AccountOwner = new() { Surname = surname, Lastname = lastname };
        }
        public void Deposit(uint amount)
        {
            this.Balance += amount;
        }
        public bool Withdraw(uint amount)
        {
            if(this.Balance < amount) return false;
            this.Balance -= amount;
            return true;

        }
    }
}
