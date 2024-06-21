using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Services;

public class CharactersService : ICharacterService
{
    private readonly ApplicationContext _applicationContext;

    public CharactersService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Character> GetCharacter(int id)
    {
        return await _applicationContext.Characters
            .Include(ch => ch.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(ch => ch.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(ch => ch.Id == id);
    }

    public Task<bool> AddItems(List<int> idList)
    {
        throw new NotImplementedException();
    }
}