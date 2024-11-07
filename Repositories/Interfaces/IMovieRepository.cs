using MovieCharactersAPI.Models;

/// <summary>
/// Repository interface for managing Movie entities
/// </summary>
public interface IMovieRepository
{
    /// <summary>
    /// Retrieves all movies from the database
    /// </summary>
    /// <returns>A collection of all movies</returns>
    Task<IEnumerable<Movie>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific movie by its ID
    /// </summary>
    /// <param name="id">The ID of the movie to retrieve</param>
    /// <returns>The movie if found, null otherwise</returns>
    Task<Movie?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new movie in the database
    /// </summary>
    /// <param name="movie">The movie entity to create</param>
    /// <returns>The created movie with updated ID</returns>
    Task<Movie> CreateAsync(Movie movie);

    /// <summary>
    /// Updates an existing movie in the database
    /// </summary>
    /// <param name="movie">The movie entity with updated values</param>
    /// <returns>The updated movie</returns>
    Task<Movie> UpdateAsync(Movie movie, List<int> characterIds);
    

    /// <summary>
    /// Deletes a movie from the database
    /// </summary>
    /// <param name="id">The ID of the movie to delete</param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Checks if a movie exists in the database
    /// </summary>
    /// <param name="id">The ID of the movie to check</param>
    /// <returns>True if the movie exists, false otherwise</returns>
    Task<bool> ExistsAsync(int id);

    /// <summary>
    /// Retrieves all movies in a specific franchise
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <returns>A collection of movies in the specified franchise</returns>
    Task<IEnumerable<Movie>> GetByFranchiseIdAsync(int franchiseId);

    /// <summary>
    /// Retrieves all characters in a specific movie
    /// </summary>
    /// <param name="movieId">The ID of the movie</param>
    /// <returns>A collection of characters in the specified movie</returns>
    Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId);
} 