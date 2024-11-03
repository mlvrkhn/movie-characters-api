using Microsoft.EntityFrameworkCore;
using Intro;

namespace MovieCharactersAPI.Data;

public class MovieCharactersDbContext : DbContext
{
    public MovieCharactersDbContext(DbContextOptions<MovieCharactersDbContext> options)
        : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
} 