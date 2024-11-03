using System.ComponentModel.DataAnnotations;

namespace Intro;

public class Movie
{
    [Key]
    public int Id { get; set; } // Autoincremented Id

    [Required]
    public string Title { get; set; } // Movie title

    [Required]
    public string Genre { get; set; } // Comma separated genres

    [Required]
    public int ReleaseYear { get; set; } // Release year

    [Required]
    public string Director { get; set; } // Director's name

    [Url]
    public string Picture { get; set; } // URL to movie poster

    [Url]
    public string Trailer { get; set; } // URL to trailer (YouTube)
} 