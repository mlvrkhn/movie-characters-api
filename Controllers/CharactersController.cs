using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Characters;
using AutoMapper;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : BaseApiController
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository, IMapper mapper)
            : base(mapper)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var characters = await _characterRepository.GetAllAsync();
            return MapAndReturn<IEnumerable<Character>, IEnumerable<CharacterDTO>>(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(id);
                return MapAndReturn<Character, CharacterDTO>(character);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> CreateCharacter(CharacterCreateDTO characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            var newCharacter = await _characterRepository.AddAsync(character);
            return MapAndReturnCreated<Character, CharacterDTO>(newCharacter, nameof(GetCharacter), new { id = newCharacter.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDTO>> UpdateCharacter(int id, CharacterUpdateDTO characterDto)
        {
            try
            {
                var existingCharacter = await _characterRepository.GetByIdAsync(id);
                _mapper.Map(characterDto, existingCharacter);
                var updatedCharacter = await _characterRepository.UpdateAsync(existingCharacter);
                return MapAndReturn<Character, CharacterDTO>(updatedCharacter);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _characterRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
} 