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
        _context.Entry(franchise).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return franchise;
    }

    public async Task DeleteAsync(int id)
    {
        var franchise = await _context.Franchises.FindAsync(id);
        if (franchise != null)
        {
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }
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
} 