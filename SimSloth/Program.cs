using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimSloth.SlothingAround;

namespace SimSloth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many sloths?");
            string readLine = string.Empty;
            while(string.IsNullOrEmpty(readLine))
            {
                readLine = Console.ReadLine();
            }
            var sloths = int.Parse(readLine);
            Console.WriteLine("What's the sloth to carer ratio?");
            readLine = string.Empty;
            while (string.IsNullOrEmpty(readLine))
            {
                readLine = Console.ReadLine();
            }
            var ratio = int.Parse(readLine);
            var sanctuary = new SlothSanctuary(sloths, ratio);
            Console.WriteLine("Press enter to tick, 's' to shuffle sloth jobs, and 'q' to escape");
            var keyChar = Console.ReadKey().KeyChar;
            while(keyChar != 'q')
            {
                if(keyChar == 's')
                {
                    Console.WriteLine("Shuffling sloth jobs...");
                    sanctuary.ShuffleSlothJobs();
                }
                sanctuary.DayToDaySlothCare();
                sanctuary.SendSlothsToWork();
                keyChar = Console.ReadKey().KeyChar;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
