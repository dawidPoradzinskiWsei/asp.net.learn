using MoviesDP.Models.Movies;

public interface IMovieServices
{
    public void Add(Movie movie);

    public void Delete(int id);

    public List<Movie> GetMovies();

    public Movie? GetMovie(int id);

    public PagingListAsync<Movie> GetMoviesByPages(int page, int size);

    public PagingListAsync<MovieCast> GetMovieCastsByPages(int page, int size, int movieId);

    public void AddPerson(PersonEntity person);
}