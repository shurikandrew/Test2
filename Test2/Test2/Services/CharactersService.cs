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

    public async Task<bool> AddItems(List<int> idList, int id)
    {
        foreach (var itemId in idList)
        {
            if (!_applicationContext.Items.Any(i => i.Id == itemId))
            {
                return false;
            }
        }

        var character = await _applicationContext.Characters.Where(ch => ch.Id == id).FirstOrDefaultAsync();

        if (character == null)
        {
            return false;
        }

        var SumWeight = 0;
        var Items = await _applicationContext.Items.Where(i => idList.Contains(i.Id)).ToListAsync();
        foreach (var item in Items)
        {
            SumWeight += item.Weight;
        }

        var capacity = character.MaxWeight - character.CurrentWeight;

        if (SumWeight > capacity)
        {
            return false;
        }

        character.CurrentWeight += SumWeight;
        character = await _applicationContext.Characters.Include(ch => ch.Backpacks).Where(ch=> ch.Id == id).FirstAsync();
        foreach (var item in Items)
        {
            var currentItem = character.Backpacks.Where(e => e.ItemId == item.Id).FirstOrDefault();
            if (currentItem != null)
            {
                currentItem.Amount += 1;
            }
            else
            {
                character.Backpacks.Add(new Backpack()
                {
                    CharacterId = id,
                    Item = item,
                    Amount = 1
                });
            }
        }
        
        await _applicationContext.SaveChangesAsync();
        return true;
    }
}