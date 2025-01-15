using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public readonly struct AccountOwner
    {
        public uint ClientId { get; }
        public required string SurName { get; init; }
        public required string LastName { get; init; }
        public string FullName => $"{this.SurName} {this.LastName}";
        public AccountOwner()
        {
            this.ClientId = (uint)new Random().Next(0, 999999);
        }
    }
}
