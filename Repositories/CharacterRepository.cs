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
                .ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Id == id) 
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
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }
    }
}
