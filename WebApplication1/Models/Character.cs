using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Character
{
    [Key]
    public int id { get; set; }
    [MaxLength(50)]
    public String firstName { get; set; } = string.Empty;
    [MaxLength(120)]
    public String lastName { get; set; } = string.Empty;
    private int CurrentWei { get; set; }
    private int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
}