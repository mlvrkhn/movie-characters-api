using MovieCharactersAPI.Features.Movies;

namespace MovieCharactersAPI.Features.Characters
{
    public class CharacterDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string? Alias { get; set; }
        public string? Gender { get; set; }
        public string? Picture { get; set; }
        public List<int> MovieIds { get; set; } = new List<int>();
    }
} 