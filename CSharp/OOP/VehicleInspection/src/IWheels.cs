using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    interface IWheels
    {
        int MaxRimSize { get; set; }
        void SetTireType(bool isWinterTire);
        string Info() => "Brug migfor alle objektersomkørespåhjul.";
    }
}
