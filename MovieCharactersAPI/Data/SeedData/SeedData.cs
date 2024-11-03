using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Data;

public static class SeedData
{
    public static readonly IEnumerable<Franchise> Franchises = new[]
    {
        new Franchise 
        { 
            Id = 1, 
            Name = "Studio Ghibli", 
            Description = "Japanese animated films produced by Studio Ghibli" 
        },
        new Franchise 
        { 
            Id = 2, 
            Name = "Hayao Miyazaki Collection", 
            Description = "Films directed by Hayao Miyazaki" 
        },
        new Franchise 
        { 
            Id = 3, 
            Name = "Isao Takahata Collection", 
            Description = "Films directed by Isao Takahata" 
        },
        new Franchise 
        { 
            Id = 4, 
            Name = "Ghibli Fantasy World", 
            Description = "Fantasy-themed Studio Ghibli films" 
        }
    };

    public static readonly IEnumerable<Movie> Movies = new[]
    {
        new Movie 
        { 
            Id = 1, 
            Title = "Spirited Away", 
            ReleaseYear = 2001,
            Genre = "Fantasy/Adventure",
            Director = "Hayao Miyazaki",
            FranchiseId = 1
        },
        new Movie 
        { 
            Id = 2, 
            Title = "My Neighbor Totoro", 
            ReleaseYear = 1988,
            Genre = "Fantasy/Family",
            Director = "Hayao Miyazaki",
            FranchiseId = 2
        },
        new Movie 
        { 
            Id = 3, 
            Title = "Princess Mononoke", 
            ReleaseYear = 1997,
            Genre = "Fantasy/Adventure",
            Director = "Hayao Miyazaki",
            FranchiseId = 4
        },
        new Movie 
        { 
            Id = 4, 
            Title = "Grave of the Fireflies", 
            ReleaseYear = 1988,
            Genre = "Drama/War",
            Director = "Isao Takahata",
            FranchiseId = 3
        }
    };

    public static readonly IEnumerable<Character> Characters = new[]
    {
        new Character 
        { 
            Id = 1, 
            FullName = "Chihiro Ogino",
            Alias = "Sen",
            Gender = "Female",
            Picture = "https://example.com/chihiro.jpg"
        },
        new Character 
        { 
            Id = 2, 
            FullName = "Totoro",
            Alias = "King of the Forest",
            Gender = "Unknown",
            Picture = "https://example.com/totoro.jpg"
        },
        new Character 
        { 
            Id = 3, 
            FullName = "San",
            Alias = "Princess Mononoke",
            Gender = "Female",
            Picture = "https://example.com/san.jpg"
        },
        new Character 
        { 
            Id = 4, 
            FullName = "Howl Jenkins Pendragon",
            Alias = "Howl",
            Gender = "Male",
            Picture = "https://example.com/howl.jpg"
        }
    };
} 