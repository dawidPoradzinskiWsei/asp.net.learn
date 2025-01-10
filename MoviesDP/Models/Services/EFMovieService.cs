using Microsoft.Data.Sqlite;
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
                .Include(b => b.Person)
                .AsAsyncEnumerable(),
            _context.MovieCasts.Count(b => b.MovieId == movieId),
            page,
            size
        );
    }

    public int NewestPersonId()
    {
        return _context.People.Max(p => p.PersonId);
    }

    public void AddPerson(PersonEntity personEntity)
    {

        // get new id
        var newsetPerson = NewestPersonId() + 1;

        // add new person
        var Person = new Person
        {
            PersonId = newsetPerson,
            PersonName = personEntity.PersonName
        };
        _context.People.Add(Person);
        _context.SaveChanges();

        // save new person id to personEntity
        personEntity.PersonId = newsetPerson;

        // mape persoEntity to movieCast
        var movieCast = PersonMapper.ToMovieCast(personEntity);

        // insert to database via sqlraw, cuz ef core can't handle tables without primary key
        var movieCastSql = "INSERT INTO movie_cast (Movie_id, Person_id, Gender_id, Character_name, Cast_order) VALUES (@MovieId, @PersonId, @GenderId, @CharacterName, @CastOrder)";
        _context.Database.ExecuteSqlRaw(movieCastSql, new[]
        {
            new SqliteParameter("@MovieId", movieCast.MovieId),
            new SqliteParameter("@PersonId", movieCast.PersonId),
            new SqliteParameter("@GenderId", movieCast.GenderId),
            new SqliteParameter("@CharacterName", movieCast.CharacterName ?? (object)DBNull.Value),
            new SqliteParameter("@CastOrder", movieCast.CastOrder ?? (object)DBNull.Value)
        });     
    }
}
