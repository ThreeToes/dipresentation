using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimSloth.SlothingAround.Recruiting;
using SimSloth.SlothingAround.Sloths;

namespace SimSloth.SlothingAround
{
    public class SlothSanctuary
    {
        private Random _random;
        private string[] _slothFirstNames = new string[]
                                                {
                                                    "Terry",
                                                    "Jimmy",
                                                    "Johnny",
                                                    "Buttercup",
                                                    "Jilly",
                                                    "Jasmine",
                                                    "Billy",
                                                    "Boromir",
                                                    "Sean",
                                                    "Alexandra",
                                                    "Eva",
                                                    "Lilith",
                                                    "Asuka",
                                                    "Luad"
                                                };

        private string[] _slothLastNames = new string[]
                                               {
                                                   "McSlow",
                                                   "O'Curious",
                                                   "Bean",
                                                   "Socks",
                                                   "Bloodbath",
                                                   "Lethargicson",
                                                   "Slothicord-Smith"
                                               };
        //Add flavour to the demo
        private string GetSlothName()
        {
            var first = _slothFirstNames[_random.Next(_slothFirstNames.Length)];
            var last = _slothLastNames[_random.Next(_slothLastNames.Length)];
            return first + " " + last;
        }

        private readonly List<SlothHandler> _handlers;
        private List<ISloth> _sloths;

        #region MEF stuff
        private CompositionContainer _container;
            
        [ImportMany(typeof(IHandlerRecruiter))]
        public IEnumerable<IHandlerRecruiter> Recruiting { get; set; }

        [ImportMany(typeof(ISlothJob))]
        public IEnumerable<ISlothJob> SlothJobs { get; set; }

        /// <summary>
        /// Compose MEF parts
        /// </summary>
        private void Compose()
        {
            var catalog = new AssemblyCatalog(GetType().Assembly);
            _container = new CompositionContainer(catalog);

            _container.ComposeParts(this);
        }
        #endregion

        public SlothSanctuary(int numberOfSloths, int slothToCarerRatio)
        {
            Compose();
            _random = new Random();
            _handlers = new List<SlothHandler>();
            _sloths = new List<ISloth>();
            
            var handler = RecruitFromBest();
            
            _handlers.Add(handler);
            var currentSloths = new List<ISloth>();
            handler.Sloths = currentSloths;
            var jobCount = SlothJobs.Count();
            for(var i = 0; i < numberOfSloths; i++)
            {
                //Randomly pick a type of sloth
                var sloth = _random.Next()%2 == 0 ? (ISloth) new ThreeToedSloth() : new TwoToedSloth();
                //Give them a name
                sloth.Name = GetSlothName();
                currentSloths.Add(sloth);
                _sloths.Add(sloth);
                if(currentSloths.Count == slothToCarerRatio && i < numberOfSloths - 1)
                {
                    handler = RecruitFromBest();
                    _handlers.Add(handler);
                    currentSloths = new List<ISloth>();
                    handler.Sloths = currentSloths;
                }
            }
            ShuffleSlothJobs();
        }

        private SlothHandler RecruitFromBest()
        {
            return Recruiting.Aggregate((currentMax, x) => currentMax == null ? x : (x.Reputation > currentMax.Reputation ? x : currentMax)).HireHandler();
        }

        public void DayToDaySlothCare()
        {
            _handlers.ForEach(x => x.CareForSloths());
        }

        public void SendSlothsToWork()
        {
            _sloths.ForEach(x => x.DoJob());
        }

        public void ShuffleSlothJobs()
        {
            var jobCount = SlothJobs.Count();
            _sloths.ForEach(x => x.Job = SlothJobs.ElementAt(_random.Next(jobCount)));
        }
    }
}
