using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Features.Characters;
using AutoMapper;

public class FranchiseRepository : IFranchiseRepository
{
    private readonly MovieCharactersDbContext _context;
    private readonly IMapper _mapper;

    public FranchiseRepository(MovieCharactersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FranchiseDTO>> GetAllAsync()
    {
        var franchises = await _context.Franchises
            .Include(f => f.Movies)
            .ToListAsync();
        return _mapper.Map<IEnumerable<FranchiseDTO>>(franchises);
    }

    public async Task<FranchiseDTO?> GetByIdAsync(int id)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id);
        return _mapper.Map<FranchiseDTO>(franchise);
    }

    public async Task<FranchiseDTO> CreateAsync(FranchiseCreateDTO franchiseCreateDto)
    {
        var franchise = _mapper.Map<Franchise>(franchiseCreateDto);
        await _context.Franchises.AddAsync(franchise);
        await _context.SaveChangesAsync();
        return _mapper.Map<FranchiseDTO>(franchise);
    }

    public async Task<FranchiseDTO> UpdateAsync(FranchiseUpdateDTO franchiseDto)
    {
        var exists = await ExistsAsync(franchiseDto.Id);
        if (!exists)
            throw new KeyNotFoundException($"Franchise with ID {franchiseDto.Id} not found");

        // Get existing franchise with movies
        var existingFranchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstAsync(f => f.Id == franchiseDto.Id);

        // Update basic properties
        _mapper.Map(franchiseDto, existingFranchise);

        await _context.SaveChangesAsync();
        
        return _mapper.Map<FranchiseDTO>(existingFranchise);
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

    public async Task<IEnumerable<FranchiseDTO>> GetByOwnerIdAsync(int ownerId)
    {
        var franchises = await _context.Franchises
            .Where(f => f.OwnerId == ownerId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<FranchiseDTO>>(franchises);
    }

    public async Task<FranchiseDTO?> GetWithMoviesAsync(int id)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == id)
            ?? throw new KeyNotFoundException($"Franchise with ID {id} not found");
        
        return _mapper.Map<FranchiseDTO>(franchise);
    }

    public async Task<FranchiseDTO?> UpdateMoviesAsync(int franchiseId, IEnumerable<int> movieIds)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .FirstOrDefaultAsync(f => f.Id == franchiseId)
            ?? throw new KeyNotFoundException($"Franchise with ID {franchiseId} not found");

        // Verify all movieIds exist and get the movies
        var movies = await _context.Movies
            .Where(m => movieIds.Contains(m.Id))
            .ToListAsync();

        // Check if all provided IDs were found
        if (movies.Count != movieIds.Count())
        {
            var foundIds = movies.Select(m => m.Id);
            var notFoundIds = movieIds.Except(foundIds);
            throw new KeyNotFoundException($"Movies with IDs {string.Join(", ", notFoundIds)} not found");
        }

        // Check if any movies belong to other franchises
        var moviesInOtherFranchises = movies.Where(m => m.FranchiseId != franchiseId);
        if (moviesInOtherFranchises.Any())
        {
            throw new InvalidOperationException($"Movies with IDs {string.Join(", ", moviesInOtherFranchises.Select(m => m.Id))} already belong to other franchises");
        }

        franchise.Movies = movies;
        await _context.SaveChangesAsync();
        return _mapper.Map<FranchiseDTO>(franchise);
    }

    public async Task<IEnumerable<CharacterDTO>> GetCharactersInFranchiseAsync(int franchiseId)
    {
        var franchise = await _context.Franchises
            .Include(f => f.Movies)
            .ThenInclude(m => m.Characters)
            .FirstOrDefaultAsync(f => f.Id == franchiseId);

        var characters = franchise?.Movies.SelectMany(m => m.Characters) ?? Enumerable.Empty<Character>();
        return _mapper.Map<IEnumerable<CharacterDTO>>(characters);
    }
} 