using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIMonitor.ReferenceTypes
{
    public class Person
    {
        public string SurName { get; set; }
        public string LastName { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BMI => new Measurement(this.Weight, this.Height).BMI;
    }
}
