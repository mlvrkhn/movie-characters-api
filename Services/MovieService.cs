using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICharacterRepository _characterRepository;

        public MovieService(IMovieRepository movieRepository, ICharacterRepository characterRepository)
        {
            _movieRepository = movieRepository;
            _characterRepository = characterRepository;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie ?? throw new KeyNotFoundException($"Movie with ID {id} not found");
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            await _movieRepository.CreateAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie, List<int> characterIds)
        {
            if (!await _movieRepository.ExistsAsync(movie.Id))
                throw new KeyNotFoundException($"Movie with ID {movie.Id} not found");

            foreach (var characterId in characterIds)
            {
                if (!await _characterRepository.ExistsAsync(characterId))
                    throw new KeyNotFoundException($"Character with ID {characterId} not found");
            }

            await _movieRepository.UpdateAsync(movie, characterIds);
        }

        public async Task DeleteMovieAsync(int id)
        {
            if (!await _movieRepository.ExistsAsync(id))
                throw new KeyNotFoundException($"Movie with ID {id} not found");
            
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Character>> GetCharactersInMovieAsync(int movieId)
        {
            return await _characterRepository.GetCharactersInMovieAsync(movieId);
        }
    }
}
