using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSloth.SlothingAround.Recruiting
{
    public class CompletelyHonestRecruiting : IHandlerRecruiter
    {
        public int Reputation { get; private set; }

        public SlothHandler HireHandler()
        {
            Reputation = 10;
            Console.WriteLine("Thank you for choosing Completely Honest Recruiting!");
            return new SlothHandler();
        }
    }
}
