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
        // Configure many-to-many relationship
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Movies)
            .WithMany(m => m.Characters)
            .UsingEntity<Dictionary<string, object>>(
                "CharacterMovie",
                j => j.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                j => j.HasOne<Character>().WithMany().HasForeignKey("CharactersId"),
                j =>
                {
                    j.ToTable("CharacterMovie");
                    j.HasKey("CharactersId", "MoviesId");
                });

        // Seed data from SeedData class
        modelBuilder.Entity<Franchise>().HasData(SeedData.Franchises);
        modelBuilder.Entity<Movie>().HasData(SeedData.Movies);
        modelBuilder.Entity<Character>().HasData(SeedData.Characters);

        // Add the many-to-many relationships
        modelBuilder.Entity("CharacterMovie").HasData(
            new { MoviesId = 1, CharactersId = 1 }, // Spirited Away - Chihiro
            new { MoviesId = 2, CharactersId = 2 }, // Totoro - Totoro
            new { MoviesId = 3, CharactersId = 3 }, // Princess Mononoke - San
            new { MoviesId = 4, CharactersId = 4 }  // Grave of the Fireflies - Howl
        );
    }
} 