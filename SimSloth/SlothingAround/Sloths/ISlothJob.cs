using System.ComponentModel.Composition;

namespace SimSloth.SlothingAround.Sloths
{
    [InheritedExport(typeof(ISlothJob))]
    public interface ISlothJob
    {
        void DoJob();
    }
}