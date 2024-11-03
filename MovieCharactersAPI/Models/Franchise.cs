using System.ComponentModel.DataAnnotations;

namespace Intro;

public class Franchise
{
    [Key]
    public int Id { get; set; } // Autoincremented Id

    [Required]
    public string Name { get; set; } // Franchise name

    [Required]
    public string Description { get; set; } // Franchise description
} 