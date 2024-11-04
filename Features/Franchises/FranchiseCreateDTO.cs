namespace MovieCharactersAPI.Features.Franchises;

public class FranchiseCreateDTO
{
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<int> MovieIds { get; set; } = new();

    public int OwnerId { get; set; }
} 