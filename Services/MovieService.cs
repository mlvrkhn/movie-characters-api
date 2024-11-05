using MovieCharactersAPI.Models;
using MovieCharactersAPI.Repositories;

namespace MovieCharactersAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
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

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.CreateAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            if (!await _movieRepository.ExistsAsync(id))
                throw new KeyNotFoundException($"Movie with ID {id} not found");
            
            await _movieRepository.DeleteAsync(id);
        }
    }
}
