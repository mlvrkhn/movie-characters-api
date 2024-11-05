using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Franchises;
using AutoMapper;

public class FranchiseService : IFranchiseService
{
    private readonly IFranchiseRepository _franchiseRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public FranchiseService(IFranchiseRepository franchiseRepository, IMovieRepository movieRepository, IMapper mapper)
    {
        _franchiseRepository = franchiseRepository;
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
    {
        var createDto = _mapper.Map<FranchiseCreateDTO>(franchise);
        var franchiseDto = await _franchiseRepository.CreateAsync(createDto);
        return _mapper.Map<Franchise>(franchiseDto);
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

        var franchiseDto = await _franchiseRepository.UpdateMoviesAsync(franchiseId, movieIds);
        return franchiseDto != null ? _mapper.Map<Franchise>(franchiseDto) : null;
    }

    public async Task<Franchise?> GetFranchiseByIdAsync(int id)
    {
        var franchiseDto = await _franchiseRepository.GetByIdAsync(id);
        return franchiseDto != null ? _mapper.Map<Franchise>(franchiseDto) : null;
    }

    public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
    {
        var franchiseDtos = await _franchiseRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<Franchise>>(franchiseDtos);
    }

    public async Task DeleteFranchiseAsync(int id)
    {
        await _franchiseRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Franchise>> GetFranchisesByOwnerAsync(int ownerId)
    {
        var franchiseDtos = await _franchiseRepository.GetByOwnerIdAsync(ownerId);
        return _mapper.Map<IEnumerable<Franchise>>(franchiseDtos);
    }

    public async Task<Franchise?> GetFranchiseWithMoviesAsync(int franchiseId)
    {
        var franchiseDto = await _franchiseRepository.GetWithMoviesAsync(franchiseId);
        return franchiseDto != null ? _mapper.Map<Franchise>(franchiseDto) : null;
    }

    public async Task<IEnumerable<Character>> GetFranchiseCharactersAsync(int franchiseId)

    {
        var characterDtos = await _franchiseRepository.GetCharactersInFranchiseAsync(franchiseId);
        return _mapper.Map<IEnumerable<Character>>(characterDtos);
    }

    public async Task<Franchise> UpdateFranchiseAsync(Franchise franchise)
    {
        var updateDto = _mapper.Map<FranchiseUpdateDTO>(franchise);
        var franchiseDto = await _franchiseRepository.UpdateAsync(updateDto);
        return _mapper.Map<Franchise>(franchiseDto);
    }
} 