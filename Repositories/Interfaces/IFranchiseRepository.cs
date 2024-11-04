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
    Task<IEnumerable<Franchise>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific franchise by its ID
    /// </summary>
    /// <param name="id">The ID of the franchise to retrieve</param>
    /// <returns>The franchise if found, null otherwise</returns>
    Task<Franchise?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new franchise in the database
    /// </summary>
    /// <param name="franchise">The franchise entity to create</param>
    /// <returns>The created franchise with updated ID</returns>
    Task<Franchise> CreateAsync(Franchise franchise);

    /// <summary>
    /// Updates an existing franchise in the database
    /// </summary>
    /// <param name="franchise">The franchise entity with updated values</param>
    /// <returns>The updated franchise</returns>
    Task<Franchise> UpdateAsync(Franchise franchise);

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
    Task<IEnumerable<Franchise>> GetByOwnerIdAsync(int ownerId);

    /// <summary>
    /// Adds a new franchise to the database
    /// </summary>
    /// <param name="franchise">The franchise entity to add</param>
    /// <returns>The added franchise with updated ID</returns>
    Task<Franchise> AddAsync(Franchise franchise);
}
