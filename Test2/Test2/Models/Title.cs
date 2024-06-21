using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();
}