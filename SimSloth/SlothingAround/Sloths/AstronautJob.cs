using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSloth.SlothingAround.Sloths
{
    public class AstronautJob : ISlothJob
    {
        public void DoJob()
        {
            Console.WriteLine("I'm an astronaut!");
        }
    }
}
