using System.ComponentModel.DataAnnotations;
namespace MovieCharactersAPI.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
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

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public bool IsDeleted { get; set; } = false;
}