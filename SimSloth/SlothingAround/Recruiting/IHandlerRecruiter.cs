using System.ComponentModel.Composition;

namespace SimSloth.SlothingAround.Recruiting
{
    [InheritedExport(typeof(IHandlerRecruiter))]
    public interface IHandlerRecruiter
    {
        int Reputation { get; }
        SlothHandler HireHandler();
    }
}
