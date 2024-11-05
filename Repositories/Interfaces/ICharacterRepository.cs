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
}