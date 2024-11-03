using MovieCharactersAPI.Models;

public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetByIdAsync(int id);
        Task<Character> AddAsync(Character character);
        Task<Character> UpdateAsync(Character character);
        Task DeleteAsync(int id);
    }