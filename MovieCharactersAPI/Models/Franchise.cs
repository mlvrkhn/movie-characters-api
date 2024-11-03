using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models;

public class Franchise
{
    [Key]
    public int Id { get; set; } // Autoincremented Id

    [Required]
    public string Name { get; set; } = string.Empty; // Franchise name

    [Required]
    public string Description { get; set; } = string.Empty; // Franchise description

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
} 
