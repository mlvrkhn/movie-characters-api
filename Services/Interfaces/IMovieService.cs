using MovieCharactersAPI.Models;

/// <summary>
/// Service interface for managing movie operations
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Retrieves a movie by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the movie</param>
    /// <returns>The movie if found, null otherwise</returns>
    Task<Movie> GetMovieByIdAsync(int id);

    /// <summary>
    /// Retrieves all movies from the database
    /// </summary>
    /// <returns>A collection of all movies</returns>
    Task<IEnumerable<Movie>> GetAllMoviesAsync();

    /// <summary>
    /// Adds a new movie to the database
    /// </summary>
    /// <param name="movie">The movie entity to add</param>
    Task AddMovieAsync(Movie movie);

    /// <summary>
    /// Updates an existing movie in the database
    /// </summary>
    /// <param name="movie">The movie entity with updated information</param>
    Task UpdateMovieAsync(Movie movie);

    /// <summary>
    /// Deletes a movie from the database
    /// </summary>
    /// <param name="id">The unique identifier of the movie to delete</param>
    Task DeleteMovieAsync(int id);
}
