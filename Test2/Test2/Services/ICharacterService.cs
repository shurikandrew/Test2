using Test2.Models;

namespace Test2.Services;

public interface ICharacterService
{
    public Task<Character> GetCharacter(int id);
    public Task<bool> AddItems(List<int> idList);
}