using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Repositories;
namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseRepository _franchiseRepository;

        public FranchisesController(IFranchiseRepository franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            var franchises = await _franchiseRepository.GetAllAsync();
            return Ok(franchises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            try
            {
                var franchise = await _franchiseRepository.GetByIdAsync(id);
                return Ok(franchise);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Franchise>> CreateFranchise(Franchise franchise)
        {
            var newFranchise = await _franchiseRepository.AddAsync(franchise);
            return CreatedAtAction(nameof(GetFranchise), new { id = newFranchise.Id }, newFranchise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Franchise>> UpdateFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
                return BadRequest();

            try
            {
                var updatedFranchise = await _franchiseRepository.UpdateAsync(franchise);
                return Ok(updatedFranchise);
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
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchisesByOwner(int ownerId)
        {
            try
            {
                var franchises = await _franchiseRepository.GetByOwnerIdAsync(ownerId);
                return Ok(franchises);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
} 