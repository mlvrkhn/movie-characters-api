using System.ComponentModel.DataAnnotations;

namespace Intro;

public class Character
{
    [Key]
    public int Id { get; set; } // Autoincremented Id

    [Required]
    public string FullName { get; set; } // Full name

    public string? Alias { get; set; } // Alias (if applicable)

    [Required]
    public string Gender { get; set; } // Gender

    [Url]
    public string Picture { get; set; } // Picture (URL to photo – do not store an image)
}