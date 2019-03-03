namespace CinemaTickets.Domain
{
    public interface IMoviesRepository
    {
        Movie GetById(Id<Movie> id);

        void Add(Movie movie);
    }
}
