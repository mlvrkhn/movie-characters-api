using MovieCharactersAPI.Models;

/// <summary>
/// Service interface for managing movie characters
/// </summary>
public interface ICharacterService
{
    /// <summary>
    /// Retrieves a character by their unique identifier
    /// </summary>
    /// <param name="id">The character's ID</param>
    /// <returns>The character if found, null otherwise</returns>
    Task<Character?> GetCharacterByIdAsync(int id);

    /// <summary>
    /// Retrieves all characters in the database
    /// </summary>
    /// <returns>A collection of all characters</returns>
    Task<IEnumerable<Character>> GetAllCharactersAsync();

    /// <summary>
    /// Adds a new character to the database
    /// </summary>
    /// <param name="character">The character to add</param>
    Task AddCharacterAsync(Character character);

    /// <summary>
    /// Updates an existing character in the database
    /// </summary>
    /// <param name="character">The character with updated information</param>
    Task UpdateCharacterAsync(Character character);

    /// <summary>
    /// Deletes a character from the database
    /// </summary>
    /// <param name="id">The ID of the character to delete</param>
    Task DeleteCharacterAsync(int id);
} 