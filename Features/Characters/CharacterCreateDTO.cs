using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Features.Characters
{
    public class CharacterCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Alias { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Picture { get; set; } = string.Empty;
    }
}
