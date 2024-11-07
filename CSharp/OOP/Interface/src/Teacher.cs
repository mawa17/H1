using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class Teacher : Person
    {
        public Teacher(in string firstName, in string lastName) : base(firstName, lastName)
        {
            
        }

        public override void SetDepartment(string value)
        {
            base.DepartmentName = "CIT";
        }
    }
}
