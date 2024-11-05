using MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Features.Characters;
using MovieCharactersAPI.Models;

/// <summary>
/// Repository interface for managing Franchise entities
/// </summary>
public interface IFranchiseRepository
{
    /// <summary>
    /// Retrieves all franchises from the database
    /// </summary>
    /// <returns>A collection of all franchises</returns>
    Task<IEnumerable<FranchiseDTO>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific franchise by its ID
    /// </summary>
    /// <param name="id">The ID of the franchise to retrieve</param>
    /// <returns>The franchise if found, null otherwise</returns>
    Task<FranchiseDTO?> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new franchise to the database
    /// </summary>
    /// <param name="franchise">The franchise entity to add</param>
    /// <returns>The added franchise with updated ID</returns>
    Task<FranchiseDTO> CreateAsync(FranchiseCreateDTO franchise);

    /// <summary>
    /// Updates an existing franchise in the database
    /// </summary>
    /// <param name="franchise">The franchise entity with updated values</param>
    /// <returns>The updated franchise</returns>
    Task<FranchiseDTO> UpdateAsync(FranchiseUpdateDTO franchise);

    /// <summary>
    /// Deletes a franchise from the database
    /// </summary>
    /// <param name="id">The ID of the franchise to delete</param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Checks if a franchise exists in the database
    /// </summary>
    /// <param name="id">The ID of the franchise to check</param>
    /// <returns>True if the franchise exists, false otherwise</returns>
    Task<bool> ExistsAsync(int id);

    /// <summary>
    /// Retrieves all franchises owned by a specific user
    /// </summary>
    /// <param name="ownerId">The ID of the owner</param>
    /// <returns>A collection of franchises owned by the specified user</returns>
    Task<IEnumerable<FranchiseDTO>> GetByOwnerIdAsync(int ownerId);

    /// <summary>
    /// Retrieves a franchise with its movies
    /// </summary>
    Task<FranchiseDTO?> GetWithMoviesAsync(int franchiseId);

    /// <summary>
    /// Updates the movies in a franchise
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <param name="movieIds">The IDs of the movies to add to the franchise</param>
    /// <returns>The updated franchise</returns>
    Task<FranchiseDTO?> UpdateMoviesAsync(int franchiseId, IEnumerable<int> movieIds);

    /// <summary>
    /// Retrieves all characters in a franchise
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <returns>A collection of characters in the specified franchise</returns>
    Task<IEnumerable<CharacterDTO>> GetCharactersInFranchiseAsync(int franchiseId);
}