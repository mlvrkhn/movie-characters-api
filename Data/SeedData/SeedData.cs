using MovieCharactersAPI.Models;
using MovieCharactersAPI.Data;
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
        },
        new Movie 
        { 
            Id = 5, 
            Title = "Howl's Moving Castle", 
            ReleaseYear = 2004,
            Genre = "Fantasy/Romance",
            Director = "Hayao Miyazaki",
            FranchiseId = 4
        },
        new Movie 
        { 
            Id = 6, 
            Title = "Kiki's Delivery Service", 
            ReleaseYear = 1989,
            Genre = "Fantasy/Coming-of-age",
            Director = "Hayao Miyazaki",
            FranchiseId = 2
        },
        new Movie 
        { 
            Id = 7, 
            Title = "Only Yesterday", 
            ReleaseYear = 1991,
            Genre = "Drama",
            Director = "Isao Takahata",
            FranchiseId = 3
        },
        new Movie 
        { 
            Id = 8, 
            Title = "Ponyo", 
            ReleaseYear = 2008,
            Genre = "Fantasy/Family",
            Director = "Hayao Miyazaki",
            FranchiseId = 4
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
        },
        new Character 
        { 
            Id = 5, 
            FullName = "Haku",
            Alias = "Nigihayami Kohaku Nushi",
            Gender = "Male",
            Picture = "https://example.com/haku.jpg"
        },
        new Character 
        { 
            Id = 6, 
            FullName = "Sophie Hatter",
            Alias = "Grandma Sophie",
            Gender = "Female",
            Picture = "https://example.com/sophie.jpg"
        },
        new Character 
        { 
            Id = 7, 
            FullName = "Kiki",
            Alias = "The Witch",
            Gender = "Female",
            Picture = "https://example.com/kiki.jpg"
        },
        new Character 
        { 
            Id = 8, 
            FullName = "Taeko Okajima",
            Alias = "None",
            Gender = "Female",
            Picture = "https://example.com/taeko.jpg"
        },
        new Character 
        { 
            Id = 9, 
            FullName = "Ponyo",
            Alias = "Brunhilde",
            Gender = "Female",
            Picture = "https://example.com/ponyo.jpg"
        },
        new Character 
        { 
            Id = 10, 
            FullName = "Sosuke",
            Alias = "None",
            Gender = "Male",
            Picture = "https://example.com/sosuke.jpg"
        }
    };

    public static readonly IEnumerable<MovieCharacter> MovieCharacters = new[]
    {
        new MovieCharacter { CharacterId = 1, MovieId = 1 }, // Chihiro in Spirited Away
        new MovieCharacter { CharacterId = 5, MovieId = 1 }, // Haku in Spirited Away
        new MovieCharacter { CharacterId = 3, MovieId = 5 }, // San in Howl's Moving Castle
        new MovieCharacter { CharacterId = 6, MovieId = 5 }, // Sophie in Howl's Moving Castle
        new MovieCharacter { CharacterId = 7, MovieId = 6 }, // Kiki in Kiki's Delivery Service
        new MovieCharacter { CharacterId = 8, MovieId = 7 }, // Taeko in Only Yesterday
        new MovieCharacter { CharacterId = 9, MovieId = 8 }, // Ponyo in Ponyo
        new MovieCharacter { CharacterId = 10, MovieId = 8 } // Sosuke in Ponyo
    };
} 