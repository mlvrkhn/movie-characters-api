using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;

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
            .ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies
            .Include(m => m.Characters)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        if (movie.FranchiseId > 0)
        {
            var franchiseExists = await _context.Franchises.AnyAsync(f => f.Id == movie.FranchiseId);
            if (!franchiseExists)
            {
                throw new InvalidOperationException($"Franchise with ID {movie.FranchiseId} does not exist");
            }
        }

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> UpdateAsync(Movie movie, List<int> characterIds)
    {
        var existingMovie = await _context.Movies
            .Include(m => m.Characters)
            .FirstOrDefaultAsync(m => m.Id == movie.Id);

        if (existingMovie == null)
            throw new KeyNotFoundException($"Movie with ID {movie.Id} not found");

        // Update scalar properties
        _context.Entry(existingMovie).CurrentValues.SetValues(movie);

        // Update characters
        existingMovie.Characters.Clear();
        var characters = await _context.Characters
            .Where(c => characterIds.Contains(c.Id))
            .ToListAsync();
        foreach (var character in characters)
        {
            existingMovie.Characters.Add(character);
        }

        await _context.SaveChangesAsync();
        return existingMovie;
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
} 