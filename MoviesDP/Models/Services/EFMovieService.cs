using Microsoft.EntityFrameworkCore;
using MoviesDP.Models.Movies;

public class EFMovieService : IMovieServices
{
    private readonly MoviesContext _context;

    public EFMovieService(MoviesContext context)
    {
        _context = context;
    }

    public void Add(Movie movie)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Movie? GetMovie(int id)
    {
        return _context.Movies.Find(id);
    }

    public List<Movie> GetMovies()
    {
       return _context.Movies.ToList();
    }

    public PagingListAsync<Movie> GetMoviesByPages(int page, int size)
    {
        return PagingListAsync<Movie>.Create(
            (p,s) => _context.Movies
            .OrderBy(b => b.MovieId)
            .Skip( (p - 1) * s)
            .Take(s)
            .AsAsyncEnumerable(),
            _context.Movies.Count(),
            page,
            size
        );
    }

    public PagingListAsync<MovieCast> GetMovieCastsByPages(int page, int size, int movieId)
    {
        return PagingListAsync<MovieCast>.Create(
            (p, s) => _context.MovieCasts
                .Where(b => b.MovieId == movieId)
                .OrderBy(b => b.CastOrder)
                .Skip((p - 1) * s)
                .Take(s)
                .Include(b => b.Person) // Include the Person entity
                .AsAsyncEnumerable(),
            _context.MovieCasts.Count(b => b.MovieId == movieId),
            page,
            size
        );
    }
}
