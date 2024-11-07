using System.ComponentModel.DataAnnotations;
using MovieCharactersAPI.Features.Characters;

namespace MovieCharactersAPI.Features.Movies;

public class MovieUpdateDTO
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

    public List<int> CharacterIds { get; set; } = new();
} 