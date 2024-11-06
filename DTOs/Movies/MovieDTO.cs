using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Features.Movies;

public class MovieDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<int> CharacterIds { get; set; } = new List<int>();
    public int? FranchiseId { get; set; }
}

public class MovieDetailDTO : MovieDTO
{
    public string? FranchiseName { get; set; }
}
