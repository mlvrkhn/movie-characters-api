using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Features.Movies;
using MovieCharactersAPI.Features.Characters;
using AutoMapper;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : BaseApiController
    {
        private readonly IMovieService _movieService;
        private readonly ICharacterService _characterService;
        public MoviesController(IMovieService movieService, ICharacterService characterService, IMapper mapper)
            : base(mapper)
        {
            _movieService = movieService;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return MapAndReturn<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {   
            try
            {
                var movie = await _movieService.GetMovieByIdAsync(id);
                if (movie == null) return NotFound();
                return MapAndReturn<Movie, MovieDTO>(movie);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie([FromBody] MovieCreateDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieService.CreateMovieAsync(movie);
            return MapAndReturnCreated<Movie, MovieDTO>(
                movie,
                nameof(GetMovie),
                new { id = movie.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDTO>> UpdateMovie(int id, [FromBody] MovieUpdateDTO movieDto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                movie.Id = id;
                await _movieService.UpdateMovieAsync(movie, movieDto.CharacterIds);
                var updatedMovie = await _movieService.GetMovieByIdAsync(id);
                return Ok(_mapper.Map<MovieDTO>(updatedMovie));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.DeleteMovieAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersInMovie(int id)
        {
            var characters = await _characterService.GetCharactersInMovieAsync(id); 
            if (characters == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<CharacterDTO>>(characters));
        }
    }
} 