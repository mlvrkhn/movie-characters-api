using MovieCharactersAPI.Models;

/// <summary>
/// Service interface for managing movie franchises
/// </summary>
public interface IFranchiseService
{
    /// <summary>
    /// Retrieves a franchise by its unique identifier
    /// </summary>
    /// <param name="id">The franchise's ID</param>
    /// <returns>The franchise if found, null otherwise</returns>
    Task<Franchise?> GetFranchiseByIdAsync(int id);

    /// <summary>
    /// Retrieves all franchises in the database
    /// </summary>
    /// <returns>A collection of all franchises</returns>
    Task<IEnumerable<Franchise>> GetAllFranchisesAsync();

    /// <summary>
    /// Adds a new franchise to the database
    /// </summary>
    /// <param name="franchise">The franchise to add</param>
    Task<Franchise> AddFranchiseAsync(Franchise franchise);

    /// <summary>
    /// Updates an existing franchise in the database
    /// </summary>
    /// <param name="franchise">The franchise with updated information</param>
    Task<Franchise> UpdateFranchiseAsync(Franchise franchise);

    /// <summary>
    /// Deletes a franchise from the database
    /// </summary>
    /// <param name="id">The ID of the franchise to delete</param>
    Task DeleteFranchiseAsync(int id);

    /// <summary>
    /// Retrieves franchises by owner ID
    /// </summary>
    /// <param name="ownerId">The ID of the owner</param>
    /// <returns>A collection of franchises</returns>
    Task<IEnumerable<Franchise>> GetFranchisesByOwnerAsync(int ownerId);

    /// <summary>
    /// Retrieves a franchise with its associated movies
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <returns>The franchise if found, null otherwise</returns>
    Task<Franchise?> GetFranchiseWithMoviesAsync(int franchiseId);

    /// <summary>
    /// Updates the movies associated with a franchise
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <param name="movieIds">The IDs of movies to associate with the franchise</param>
    Task<Franchise?> UpdateFranchiseMoviesAsync(int franchiseId, int[] movieIds);

    /// <summary>
    /// Retrieves characters associated with a franchise
    /// </summary>
    /// <param name="franchiseId">The ID of the franchise</param>
    /// <returns>A collection of characters</returns>
    Task<IEnumerable<Character>> GetFranchiseCharactersAsync(int franchiseId);
} 