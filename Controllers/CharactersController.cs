using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Characters;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var characters = await _characterRepository.GetAllAsync();
            var characterDtos = characters.Select(c => new CharacterDTO
            {
                Id = c.Id,
                Name = c.FullName,
                Alias = c.Alias,
                Gender = c.Gender,
                Picture = c.Picture,
                MovieIds = c.Movies.Select(m => m.Id).ToList()
            });
            
            return Ok(characterDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                var character = await _characterRepository.GetByIdAsync(id);
                return Ok(character);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            var newCharacter = await _characterRepository.AddAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.Id }, newCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Character>> UpdateCharacter(int id, Character character)
        {
            if (id != character.Id)
                return BadRequest();

            try
            {
                var updatedCharacter = await _characterRepository.UpdateAsync(character);
                return Ok(updatedCharacter);
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