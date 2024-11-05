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
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
            : base(mapper)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            return MapAndReturn<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {   
            try
            {
                var movie = await _movieRepository.GetByIdAsync(id);
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
            var createdMovie = await _movieRepository.CreateAsync(movie);
            return MapAndReturnCreated<Movie, MovieDTO>(
                createdMovie, 
                nameof(GetMovie), 
                new { id = createdMovie.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDTO>> UpdateMovie(int id, [FromBody] MovieUpdateDTO movieDto)
        {
            if (id != movieDto.Id)
                return BadRequest();

            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                var updatedMovie = await _movieRepository.UpdateAsync(movie);
                return MapAndReturn<Movie, MovieDTO>(updatedMovie);
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
                await _movieRepository.DeleteAsync(id);
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
            var characters = await _movieRepository.GetCharactersInMovieAsync(id);
            return MapAndReturn<IEnumerable<Character>, IEnumerable<CharacterDTO>>(characters);
        }
    }
} 