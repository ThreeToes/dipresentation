namespace SimSloth.SlothingAround.Sloths
{
    public interface ISloth
    {
        ISlothJob Job { get; set; }
        string Name { get; set; }

        void DoJob();
    }
}
