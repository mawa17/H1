using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class SendEmail
    {
        public string Send(IDepartment person) 
        {
            string? message = null;
            if(person is Teacher)
            {
                message = $"Email sent to Teacher";
            }
            else if(person is Student)
            {
                message = $"Email sent to Student";
            }
            return message;
        }
    }
}
