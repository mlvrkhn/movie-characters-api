using MovieCharactersAPI.Models;

public interface IMovieService
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
}
