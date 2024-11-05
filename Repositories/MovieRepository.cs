using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;

/// <summary>
/// Implementation of IMovieRepository for managing Movie entities
/// </summary>
public class MovieRepository : IMovieRepository
{
    private readonly MovieCharactersDbContext _context;

    public MovieRepository(MovieCharactersDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _context.Movies
            .Include(m => m.Characters)
            .Include(m => m.Franchise)
            .ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.Characters)
            .Include(m => m.Franchise)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Movies.AnyAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Movie>> GetByFranchiseIdAsync(int franchiseId)
    {
        return await _context.Movies
            .Include(m => m.Characters)
            .Where(m => m.FranchiseId == franchiseId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId)
    {
        var movie = await _context.Movies
            .Include(m => m.Characters)
            .FirstOrDefaultAsync(m => m.Id == movieId);
        return movie?.Characters ?? new List<Character>();
    }

    public async Task<Movie?> UpdateCharactersInMovieAsync(int movieId, IEnumerable<int> characterIds)
    {
        var movie = await GetByIdAsync(movieId);
        if (movie == null) throw new KeyNotFoundException("Movie not found");

        movie.Characters = await _context.Characters.Where(c => characterIds.Contains(c.Id)).ToListAsync();
        await _context.SaveChangesAsync();
        return movie;
    }
} 