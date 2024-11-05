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
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService, IMapper mapper)
            : base(mapper)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            try
            {
                var character = await _characterService.GetCharacterByIdAsync(id);
                return Ok(character);
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
            var newCharacter = await _characterService.AddCharacterAsync(characterDto);
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, newCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDTO>> UpdateCharacter(int id, CharacterUpdateDTO characterDto)
        {
            try
            {
                var updatedCharacter = await _characterService.UpdateCharacterAsync(id, characterDto);
                return Ok(updatedCharacter);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _characterService.DeleteCharacterAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
} 