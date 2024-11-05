using MovieCharactersAPI.Models;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Data;

namespace MovieCharactersAPI.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterRepository(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters
                .Include(c => c.Movies)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found");
        }

        public async Task<Character> AddAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> UpdateAsync(Character character)
        {
            var existingCharacter = await _context.Characters.FindAsync(character.Id)
                ?? throw new KeyNotFoundException($"Character with ID {character.Id} not found");
            
            _context.Entry(existingCharacter).CurrentValues.SetValues(character);
            await _context.SaveChangesAsync();
            return existingCharacter;
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found");
            
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id)
                ?? throw new KeyNotFoundException($"Character with ID {id} not found");
            
            character.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
