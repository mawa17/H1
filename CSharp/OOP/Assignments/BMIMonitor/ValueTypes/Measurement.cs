using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public readonly struct Measurement(int weight, int height)
{
    public int BMI => (int)(weight / (Math.Pow(height, 2)));
}
