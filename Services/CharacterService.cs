using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;
using MovieCharactersAPI.Models;


public class CharacterService : ICharacterService
{
    private readonly MovieCharactersDbContext _context;

    public CharacterService(MovieCharactersDbContext context)
    {
        _context = context;
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters
            .Include(c => c.Movies)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters
            .Include(c => c.Movies)
            .ToListAsync();
    }

    public async Task AddCharacterAsync(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCharacterAsync(Character character)
    {
        _context.Entry(character).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character != null)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
} 