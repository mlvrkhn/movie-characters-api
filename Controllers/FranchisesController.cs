using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Features.Characters;
using MovieCharactersAPI.Features.Movies;
using AutoMapper;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranchisesController : BaseApiController
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IFranchiseRepository franchiseRepository, IMapper mapper, IFranchiseService franchiseService)
            : base(mapper)
        {
            _franchiseRepository = franchiseRepository;
            _franchiseService = franchiseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            var franchises = await _franchiseRepository.GetAllAsync();
            if (franchises == null) return NotFound();
            return MapAndReturn<IEnumerable<FranchiseDTO>, IEnumerable<FranchiseDTO>>(franchises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseRepository.GetByIdAsync(id);
                if (franchise == null) return NotFound();
                return MapAndReturn<FranchiseDTO, FranchiseDTO>(franchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> Post([FromBody] FranchiseCreateDTO franchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(franchiseDto);
            var result = await _franchiseService.AddFranchiseAsync(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = result.Id }, _mapper.Map<FranchiseDTO>(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FranchiseDTO>> UpdateFranchise(int id, FranchiseUpdateDTO franchiseDto)
        {
            if (id != franchiseDto.Id)
                return BadRequest();

            try
            {
                var updatedFranchise = await _franchiseRepository.UpdateAsync(franchiseDto);
                return MapAndReturn<FranchiseDTO, FranchiseDTO>(updatedFranchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchiseRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchisesByOwner(int ownerId)
        {
            try
            {
                var franchises = await _franchiseRepository.GetByOwnerIdAsync(ownerId);
                if (franchises == null) return NotFound();
                return MapAndReturn<IEnumerable<FranchiseDTO>, IEnumerable<FranchiseDTO>>(franchises);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersInFranchise(int id)
        {
            var characters = await _franchiseRepository.GetCharactersInFranchiseAsync(id);
            if (characters == null) return NotFound();
            return MapAndReturn<IEnumerable<CharacterDTO>, IEnumerable<CharacterDTO>>(characters);
        }

        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesInFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseRepository.GetWithMoviesAsync(id);
                if (franchise == null) return NotFound();
                return MapAndReturn<IEnumerable<MovieDTO>, IEnumerable<MovieDTO>>(franchise.Movies);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/movies")]
        public async Task<ActionResult<FranchiseDTO>> UpdateMoviesInFranchise(int id, [FromBody] IEnumerable<int> movieIds)
        {
            try
            {
                var franchise = await _franchiseRepository.UpdateMoviesAsync(id, movieIds);
                if (franchise == null) return NotFound();
                return MapAndReturn<FranchiseDTO, FranchiseDTO>(franchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
} 