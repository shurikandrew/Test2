namespace Test2.Models.DTOs;

public class CharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<ItemDTO> BackpackItems { get; set; } = new List<ItemDTO>();
    public ICollection<TitleDTO> Titles { get; set; } = new List<TitleDTO>();
}