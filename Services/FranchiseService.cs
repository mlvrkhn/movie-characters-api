using MovieCharactersAPI.Models;

public class FranchiseService : IFranchiseService
{
    private readonly IFranchiseRepository _franchiseRepository;
    private readonly IMovieRepository _movieRepository;

    public FranchiseService(IFranchiseRepository franchiseRepository, IMovieRepository movieRepository)
    {
        _franchiseRepository = franchiseRepository;
        _movieRepository = movieRepository;
    }

    public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
    {
        if (string.IsNullOrEmpty(franchise.Name))
            throw new ArgumentException("Franchise name cannot be empty");

        return await _franchiseRepository.AddAsync(franchise);
    }

    public async Task<Franchise?> UpdateFranchiseMoviesAsync(int franchiseId, int[] movieIds)
    {
        if (!await _franchiseRepository.ExistsAsync(franchiseId))
            throw new KeyNotFoundException($"Franchise with ID {franchiseId} not found");

        foreach (var movieId in movieIds)
        {
            if (!await _movieRepository.ExistsAsync(movieId))
                throw new KeyNotFoundException($"Movie with ID {movieId} not found");
        }

        return await _franchiseRepository.UpdateMoviesAsync(franchiseId, movieIds);
    }

    public async Task<Franchise?> GetFranchiseByIdAsync(int id)
    {
        return await _franchiseRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
    {
        return await _franchiseRepository.GetAllAsync();
    }

    public async Task DeleteFranchiseAsync(int id)
    {
        await _franchiseRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Franchise>> GetFranchisesByOwnerAsync(int ownerId)
    {
        return await _franchiseRepository.GetByOwnerIdAsync(ownerId);
    }

    public async Task<Franchise?> GetFranchiseWithMoviesAsync(int franchiseId)
    {
        return await _franchiseRepository.GetWithMoviesAsync(franchiseId);
    }

    public async Task<IEnumerable<Character>> GetFranchiseCharactersAsync(int franchiseId)
    {
        return await _franchiseRepository.GetCharactersInFranchiseAsync(franchiseId);
    }

    public async Task<Franchise> UpdateFranchiseAsync(Franchise franchise)
    {
        return await _franchiseRepository.UpdateAsync(franchise);
    }
} 