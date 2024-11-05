using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;


/// <summary>
/// Implementation of IFranchiseRepository for managing Franchise entities
/// </summary>
public class FranchiseRepository : IFranchiseRepository
{
    private readonly MovieCharactersDbContext _context;

    public FranchiseRepository(MovieCharactersDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Franchise>> GetAllAsync()
    {
        return await _context.Franchises
            .Include(f => f.Movies)
            .ToListAsync();
    }

    public async Task<Franchise?> GetByIdAsync(int id)
    {
        return await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Franchise> CreateAsync(Franchise franchise)
    {
        _context.Franchises.Add(franchise);
        await _context.SaveChangesAsync();
        return franchise;
    }

    public async Task<Franchise> UpdateAsync(Franchise franchise)
    {
        var exists = await ExistsAsync(franchise.Id);
        if (!exists)
            throw new KeyNotFoundException($"Franchise with ID {franchise.Id} not found");

        // Get existing franchise with movies
        var existingFranchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstAsync(f => f.Id == franchise.Id);

        // Update basic properties
        _context.Entry(existingFranchise).CurrentValues.SetValues(franchise);

        // Update movie relationships if MovieIds are provided
        if (franchise.Movies != null)
        {
            existingFranchise.Movies = franchise.Movies;
        }

        await _context.SaveChangesAsync();
        return existingFranchise;
    }

    public async Task DeleteAsync(int id)
    {
        var franchise = await _context.Franchises.FindAsync(id)
            ?? throw new KeyNotFoundException($"Franchise with ID {id} not found");
        
        _context.Franchises.Remove(franchise);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Franchises.AnyAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Franchise>> GetByOwnerIdAsync(int ownerId)
    {
        return await _context.Franchises
            .Where(f => f.OwnerId == ownerId)
            .ToListAsync();
    }

    public async Task<Franchise> AddAsync(Franchise franchise)
    {
        await _context.Franchises.AddAsync(franchise);
        await _context.SaveChangesAsync();
        return franchise;
    }

    public async Task<Franchise?> GetWithMoviesAsync(int id)
    {
        return await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id)
            ?? throw new KeyNotFoundException($"Franchise with ID {id} not found");
    }

    public async Task<Franchise?> UpdateMoviesAsync(int franchiseId, IEnumerable<int> movieIds)
    {
        var franchise = await GetByIdAsync(franchiseId);
        if (franchise == null)
            throw new KeyNotFoundException($"Franchise with ID {franchiseId} not found");

        var movies = await _context.Movies
            .Where(m => movieIds.Contains(m.Id))
            .ToListAsync();

        franchise.Movies = movies;
        await _context.SaveChangesAsync();
        return franchise;
    }

    public async Task<IEnumerable<Character>> GetCharactersInFranchiseAsync(int franchiseId)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .ThenInclude(m => m.Characters)
            .FirstOrDefaultAsync(f => f.Id == franchiseId);

        return franchise?.Movies.SelectMany(m => m.Characters) ?? Enumerable.Empty<Character>();
    }
} 