using MoviesDP.Models.Movies;

public class PersonMapper
{
    public static MovieCast ToMovieCast(PersonEntity personEntity)
    {
        return new MovieCast
        {
            MovieId = personEntity.MovieId,
            PersonId = personEntity.PersonId,
            CharacterName = personEntity.CharacterName,
            GenderId = (int)personEntity.Gender,
            CastOrder = personEntity.CastOrder
        };
    }
}