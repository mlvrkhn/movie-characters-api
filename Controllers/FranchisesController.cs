using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Franchises;
using AutoMapper;
using MovieCharactersAPI.Features.Characters;
using MovieCharactersAPI.Features.Movies;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranchisesController : BaseApiController
    {
        private readonly IFranchiseRepository _franchiseRepository;

        public FranchisesController(IFranchiseRepository franchiseRepository, IMapper mapper)
            : base(mapper)
        {
            _franchiseRepository = franchiseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            var franchises = await _franchiseRepository.GetAllAsync();
            if (franchises == null) return NotFound();
            return MapAndReturn<IEnumerable<Franchise>, IEnumerable<FranchiseDTO>>(franchises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseRepository.GetByIdAsync(id);
                if (franchise == null) return NotFound();
                return MapAndReturn<Franchise, FranchiseDTO>(franchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> CreateFranchise([FromBody] FranchiseCreateDTO franchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(franchiseDto);
            var newFranchise = await _franchiseRepository.AddAsync(franchise);
            return MapAndReturnCreated<Franchise, FranchiseDTO>(
                newFranchise,
                nameof(GetFranchise),
                new { id = newFranchise.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FranchiseDTO>> UpdateFranchise(int id, FranchiseUpdateDTO franchiseDto)
        {
            if (id != franchiseDto.Id)
                return BadRequest();

            try
            {
                var franchise = _mapper.Map<Franchise>(franchiseDto);
                var updatedFranchise = await _franchiseRepository.UpdateAsync(franchise);
                return MapAndReturn<Franchise, FranchiseDTO>(updatedFranchise);
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
                return MapAndReturn<IEnumerable<Franchise>, IEnumerable<FranchiseDTO>>(franchises);
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
            return MapAndReturn<IEnumerable<Character>, IEnumerable<CharacterDTO>>(characters);
        }

        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesInFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseRepository.GetWithMoviesAsync(id);
                if (franchise == null) return NotFound();
                return MapAndReturn<IEnumerable<Movie>, IEnumerable<MovieDTO>>(franchise.Movies);
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
                return MapAndReturn<Franchise, FranchiseDTO>(franchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
} 