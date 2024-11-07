using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }

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

    // Navigation property for characters
    public ICollection<Character> Characters { get; set; } = new List<Character>();

    public int FranchiseId { get; set; }
} 
