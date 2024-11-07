using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;
        public Startup(ServiceProvider serviceExample)
        {
            this._serviceProvider = serviceExample;
        }
        public void Main()
        {
            var service = _serviceProvider.GetService<DPServiceExample>();
            Console.WriteLine(service.GetHelloMessage());
        }
    }
}
