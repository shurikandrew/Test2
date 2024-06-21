using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test2.Models;
[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
}