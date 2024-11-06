using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Features.Movies;

public class MovieCreateDTO
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    [MaxLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Director { get; set; } = string.Empty;

    public int FranchiseId { get; set; }
    public List<int> CharacterIds { get; set; } = new List<int>();
} 