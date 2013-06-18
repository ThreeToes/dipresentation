using System;

namespace SimSloth.SlothingAround.Recruiting
{
    public class DodgyBrosRecruiting : IHandlerRecruiter
    {
        public int Reputation { get; private set; }

        public SlothHandler HireHandler()
        {
            Reputation = 0;
            Console.WriteLine("Thank you for choosing Dodgy Bros!");
            return new SlothHandler();
        }
    }
}
