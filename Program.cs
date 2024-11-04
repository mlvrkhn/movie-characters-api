using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Services;
using MovieCharactersAPI.Features.Characters;
using MovieCharactersAPI.Features.Movies;
using MovieCharactersAPI.Features.Franchises;
using MovieCharactersAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    // Character mappings
    cfg.CreateMap<Character, CharacterDTO>();
    cfg.CreateMap<CharacterCreateDTO, Character>();
    cfg.CreateMap<CharacterUpdateDTO, Character>();

    // Movie mappings
    cfg.CreateMap<Movie, MovieDTO>();
    cfg.CreateMap<MovieCreateDTO, Movie>();
    cfg.CreateMap<MovieUpdateDTO, Movie>();

    // Franchise mappings
    cfg.CreateMap<Franchise, FranchiseDTO>();
    cfg.CreateMap<FranchiseCreateDTO, Franchise>();
    cfg.CreateMap<FranchiseUpdateDTO, Franchise>();
}, AppDomain.CurrentDomain.GetAssemblies());

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
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

