using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoHub
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeter;

        public Greeter(IConfiguration configuration)
        {
            _greeter = configuration["Greeting"];
        }
        public string GetGreeting()
        {
            return _greeter;
        }
    }
}
