using MovieCharactersAPI.Models;

public interface ICharacterRepository
{
    /// <summary>
    /// Retrieves all characters from the database asynchronously
    /// </summary>
    /// <returns>A collection of all characters</returns>
    Task<IEnumerable<Character>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific character by their ID asynchronously
    /// </summary>
    /// <param name="id">The ID of the character to retrieve</param>
    /// <returns>The character with the specified ID</returns>
    Task<Character> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new character to the database asynchronously
    /// </summary>
    /// <param name="character">The character to add</param>
    /// <returns>The added character with updated information</returns>
    Task<Character> AddAsync(Character character);

    /// <summary>
    /// Updates an existing character in the database asynchronously
    /// </summary>
    /// <param name="character">The character with updated information</param>
    /// <returns>The updated character</returns>
    Task<Character> UpdateAsync(Character character);

    /// <summary>
    /// Deletes a character from the database asynchronously
    /// </summary>
    /// <param name="id">The ID of the character to delete</param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Marks a character as deleted in the database asynchronously
    /// </summary>
    /// <param name="id">The ID of the character to mark as deleted</param>
    Task SoftDeleteAsync(int id);

    /// <summary>
    /// Retrieves all characters in a specific movie
    /// </summary>
    /// <param name="movieId">The ID of the movie</param>
    /// <returns>A collection of characters in the specified movie</returns>
    Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId);

    /// <summary>
    /// Checks if a character exists by their ID
    /// </summary>
    Task<bool> ExistsAsync(int id);
}
