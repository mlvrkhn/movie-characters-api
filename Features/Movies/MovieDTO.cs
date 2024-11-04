using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Features.Movies;

public class MovieDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Genre { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int FranchiseId { get; set; }
}

public class MovieDetailDTO : MovieDTO
{
    public List<int> CharacterIds { get; set; } = new List<int>();
    public string? FranchiseName { get; set; }
}
