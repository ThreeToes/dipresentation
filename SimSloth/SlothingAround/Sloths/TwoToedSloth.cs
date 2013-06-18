using System;

namespace SimSloth.SlothingAround.Sloths
{
    public class TwoToedSloth : ISloth
    {
        public ISlothJob Job { get; set; }
        public string Name { get; set; }

        public void DoJob()
        {
            Console.WriteLine("{0} going to work!", Name);
            Job.DoJob();
            Console.WriteLine();
        }
    }
}