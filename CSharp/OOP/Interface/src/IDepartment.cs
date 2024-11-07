using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    interface IDepartment /*The*/
    {
        string DepartmentName { get; set; }
        void SetDepartment(string value);

        string GetInfo() => $"Use this inferface for eveyr type that need department name";
    }
}
