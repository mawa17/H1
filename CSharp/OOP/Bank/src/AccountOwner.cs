using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public struct AccountOwner
    {
        public uint ClientId { get; }
        public required string Surname { get; init; }
        public required string Lastname { get; init; }
        public AccountOwner()
        {
            this.ClientId = (uint)new Random().Next(0, 999999);
        }
    }
}
