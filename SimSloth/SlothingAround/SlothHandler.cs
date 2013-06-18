using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimSloth.SlothingAround.Sloths;

namespace SimSloth.SlothingAround
{
    public class SlothHandler
    {
        private static int IdCounter = 0;
        public IEnumerable<ISloth> Sloths { get; set; }
        private int _id;

        public SlothHandler()
        {
            _id = IdCounter;
            IdCounter++;
        }
 
        public void CareForSloths()
        {
            Console.WriteLine("Carer {0}: I'm going to look after my sloths!", _id);
            foreach (var sloth in Sloths)
            {
                CareFor(sloth);
            }
            Console.WriteLine();
        }

        private void CareFor(ISloth sloth)
        {
            Console.WriteLine("Caring for {0}", sloth.Name);
        }
    }
}
