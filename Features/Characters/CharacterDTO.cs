using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Features.Characters
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        // You might want to include a simplified version of movies
        public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
        // public ICollection<int> MovieIds { get; set; } = new List<int>();
    }
} 