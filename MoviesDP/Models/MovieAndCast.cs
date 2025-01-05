using MoviesDP.Models.Movies;

public class MovieAndCast
{
    public Movie Movie { get; set; }
    public PagingListAsync<MovieCast> MovieCasts { get; set; }
}