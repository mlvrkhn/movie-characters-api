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
        // Validation
        if (string.IsNullOrEmpty(characterDto.FullName))
            throw new ArgumentException("Character name cannot be empty");

        // Map DTO to entity
        var character = _mapper.Map<Character>(characterDto);
        
        // Save to database
        var savedCharacter = await _characterRepository.AddAsync(character);
        
        // Map back to DTO
        return _mapper.Map<CharacterDTO>(savedCharacter);
    }

    public async Task<CharacterDTO> UpdateCharacterAsync(int id, CharacterUpdateDTO characterDto)
    {
        // Validation
        if (string.IsNullOrEmpty(characterDto.FullName))
            throw new ArgumentException("Character name cannot be empty");

        var existingCharacter = await _characterRepository.GetByIdAsync(id);
        _mapper.Map(characterDto, existingCharacter);
        
        var updatedCharacter = await _characterRepository.UpdateAsync(existingCharacter);
        return _mapper.Map<CharacterDTO>(updatedCharacter);
    }

    public async Task<CharacterDTO?> GetCharacterByIdAsync(int id)
    {
        try
        {
            var character = await _characterRepository.GetByIdAsync(id);
            return character == null ? throw new Exception($"Character with ID {id} not found") : _mapper.Map<CharacterDTO>(character);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to retrieve character: {ex.Message}");
        }
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
} 