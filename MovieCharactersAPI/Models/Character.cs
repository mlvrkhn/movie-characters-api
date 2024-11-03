using System.ComponentModel.DataAnnotations;
namespace MovieCharactersAPI.Models;

public class Character
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }

    [MaxLength(100)]
    public string? Alias { get; set; }

    [Required]
    [MaxLength(50)]
    public string Gender { get; set; }

    [Required]
    [Url]
    public string Picture { get; set; }

    public int? MovieId { get; set; }
    public Movie? Movie { get; set; }
}