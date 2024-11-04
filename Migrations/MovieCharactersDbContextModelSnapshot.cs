﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersAPI.Data;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    [DbContext(typeof(MovieCharactersDbContext))]
    partial class MovieCharactersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie", (string)null);

                    b.HasData(
                        new
                        {
                            CharactersId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            CharactersId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            CharactersId = 3,
                            MoviesId = 3
                        },
                        new
                        {
                            CharactersId = 4,
                            MoviesId = 4
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Sen",
                            FullName = "Chihiro Ogino",
                            Gender = "Female",
                            Picture = "https://example.com/chihiro.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "King of the Forest",
                            FullName = "Totoro",
                            Gender = "Unknown",
                            Picture = "https://example.com/totoro.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Princess Mononoke",
                            FullName = "San",
                            Gender = "Female",
                            Picture = "https://example.com/san.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Howl",
                            FullName = "Howl Jenkins Pendragon",
                            Gender = "Male",
                            Picture = "https://example.com/howl.jpg"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Japanese animated films produced by Studio Ghibli",
                            Name = "Studio Ghibli",
                            OwnerId = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Films directed by Hayao Miyazaki",
                            Name = "Hayao Miyazaki Collection",
                            OwnerId = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Films directed by Isao Takahata",
                            Name = "Isao Takahata Collection",
                            OwnerId = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fantasy-themed Studio Ghibli films",
                            Name = "Ghibli Fantasy World",
                            OwnerId = 0
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 1,
                            Genre = "Fantasy/Adventure",
                            ReleaseYear = 2001,
                            Title = "Spirited Away"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 2,
                            Genre = "Fantasy/Family",
                            ReleaseYear = 1988,
                            Title = "My Neighbor Totoro"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 4,
                            Genre = "Fantasy/Adventure",
                            ReleaseYear = 1997,
                            Title = "Princess Mononoke"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Isao Takahata",
                            FranchiseId = 3,
                            Genre = "Drama/War",
                            ReleaseYear = 1988,
                            Title = "Grave of the Fireflies"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
