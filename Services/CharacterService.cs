using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Characters;
using AutoMapper;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<CharacterDTO> AddCharacterAsync(CharacterCreateDTO characterDto)
    {
        if (string.IsNullOrEmpty(characterDto.FullName))
            throw new ArgumentException("Character name cannot be empty");

        var character = _mapper.Map<Character>(characterDto);
        
        var savedCharacter = await _characterRepository.AddAsync(character);
        
        return _mapper.Map<CharacterDTO>(savedCharacter);
    }

    public async Task<CharacterDTO> UpdateCharacterAsync(int id, CharacterUpdateDTO characterDto)
    {
        if (string.IsNullOrEmpty(characterDto.FullName))
            throw new ArgumentException("Character name cannot be empty");

        var existingCharacter = await _characterRepository.GetByIdAsync(id);
        _mapper.Map(characterDto, existingCharacter);
        
        var updatedCharacter = await _characterRepository.UpdateAsync(existingCharacter);
        return _mapper.Map<CharacterDTO>(updatedCharacter);
    }

    public async Task<CharacterDTO?> GetCharacterByIdAsync(int id)
    {
        var character = await _characterRepository.GetByIdAsync(id);
        return _mapper.Map<CharacterDTO>(character);
    }

    public async Task<IEnumerable<CharacterDTO>> GetAllCharactersAsync()
    {
        var characters = await _characterRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CharacterDTO>>(characters);
    }

    public async Task DeleteCharacterAsync(int id)
    {
        await _characterRepository.DeleteAsync(id);
    }

    public async Task SoftDeleteCharacterAsync(int id)
    {
        await _characterRepository.SoftDeleteAsync(id);
    }

    public async Task<IEnumerable<CharacterDTO>> GetCharactersInMovieAsync(int movieId)
    {
        var characters = await _characterRepository.GetCharactersInMovieAsync(movieId);
        return _mapper.Map<IEnumerable<CharacterDTO>>(characters);
    }
} 