using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieCharacterController : ControllerBase
    {
        private readonly MovieCharactersDbContext _context;

        public MovieCharacterController(MovieCharactersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }
        // ... other endpoints
    }
} 