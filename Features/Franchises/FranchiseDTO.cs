namespace MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Features.Movies;

public class FranchiseDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<int> MovieIds { get; set; } = new();

    public int OwnerId { get; set; }

    public ICollection<MovieDTO> Movies { get; set; } = new List<MovieDTO>();
}
