using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal abstract class Person(in string firstName, in string lastName) : IDepartment
    {
        public string DepartmentName { get; set; }
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;

        public virtual void SetDepartment(string value)
        {
            this.DepartmentName = value;
        }
        //public string? GetInterfaceInfo() => (this as IDepartment)?.GetInfo();
        public string GetInterfaceInfo()
        {
            IDepartment department = this;
            return department.GetInfo();
        }
    }
}
