﻿using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Services;
using MovieCharactersAPI.Features.Characters;
using MovieCharactersAPI.Features.Movies;
using MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    // Character mappings
    cfg.CreateMap<Character, CharacterDTO>();
    cfg.CreateMap<CharacterCreateDTO, Character>();
    cfg.CreateMap<CharacterUpdateDTO, Character>();

    // Movie mappings
    cfg.CreateMap<Movie, MovieDTO>()
        .ForMember(dest => dest.CharacterIds, opt => opt.MapFrom(src => 
            src.Characters.Select(c => c.Id).ToList()));
    cfg.CreateMap<MovieCreateDTO, Movie>();
    cfg.CreateMap<MovieUpdateDTO, Movie>()
        .ForMember(dest => dest.Characters, opt => opt.Ignore());

    // Franchise mappings
    cfg.CreateMap<Franchise, FranchiseDTO>().ReverseMap();
    cfg.CreateMap<FranchiseCreateDTO, Franchise>().ReverseMap();
    cfg.CreateMap<FranchiseUpdateDTO, Franchise>();
}, AppDomain.CurrentDomain.GetAssemblies());

// Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IFranchiseRepository, FranchiseRepository>();

// Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IFranchiseService, FranchiseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieCharactersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Create/initialize database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MovieCharactersDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}
else 
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();
app.Run();