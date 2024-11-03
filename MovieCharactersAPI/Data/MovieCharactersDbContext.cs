using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Data;

public class MovieCharactersDbContext : DbContext
{
    public MovieCharactersDbContext(DbContextOptions<MovieCharactersDbContext> options)
        : base(options)
    {
    }

    #nullable disable
    public DbSet<Character> Characters { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    #nullable restore

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many-to-Many: Movies and Characters
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Movies)
            .WithMany(m => m.Characters)
            .UsingEntity(j => j.ToTable("MovieCharacter"));
    }
} 