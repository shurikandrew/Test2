using Microsoft.AspNetCore.Mvc;
using Test2.Models.DTOs;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var ch = await _characterService.GetCharacter(id);

        return Ok( new CharacterDTO()
        {
            FirstName = ch.FirstName,
            LastName = ch.LastName,
            CurrentWeight = ch.CurrentWeight,
            MaxWeight = ch.MaxWeight,
            BackpackItems = ch.Backpacks.Select(b => new ItemDTO()
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = ch.CharacterTitles.Select(ct => new TitleDTO()
            {
                Title = ct.Title.Name,
                AcquiredAt = ct.AcquiredAt
            }).ToList()
        });
    }

    [HttpPost("{id:int}/backpacks")]
    public async Task<IActionResult> AddItem(List<int> )
    {
        
    }
}