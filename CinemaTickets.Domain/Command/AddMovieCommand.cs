namespace CinemaTickets.Domain.Command
{
    public sealed class AddMovieCommand : ICommand
    {
        public AddMovieCommand(string name, int year, int seanceTime)
        {
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }

        public string Name { get; }
        public int Year { get; }
        public int SeanceTime { get; }
    }
}