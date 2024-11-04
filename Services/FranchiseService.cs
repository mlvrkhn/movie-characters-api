using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models;

public class FranchiseService : IFranchiseService
{
    private readonly MovieCharactersDbContext _context;

    public FranchiseService(MovieCharactersDbContext context)
    {
        _context = context;
    }

    public async Task<Franchise?> GetFranchiseByIdAsync(int id)
    {
        return await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
    {
        return await _context.Franchises
            .Include(f => f.Movies)
            .ToListAsync();
    }

    public async Task AddFranchiseAsync(Franchise franchise)
    {
        await _context.Franchises.AddAsync(franchise);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFranchiseAsync(Franchise franchise)
    {
        _context.Entry(franchise).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFranchiseAsync(int id)
    {
        var franchise = await _context.Franchises.FindAsync(id);
        if (franchise != null)
        {
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateFranchiseMoviesAsync(int franchiseId, int[] movieIds)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == franchiseId);

        if (franchise == null)
            throw new KeyNotFoundException($"Franchise with ID {franchiseId} not found");

        var movies = await _context.Movies
            .Where(m => movieIds.Contains(m.Id))
            .ToListAsync();

        franchise.Movies.Clear();
        foreach (var movie in movies)
        {
            franchise.Movies.Add(movie);
        }

        await _context.SaveChangesAsync();
    }
} 