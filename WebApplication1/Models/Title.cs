using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Title
{
    [Key]
    public int id { get; set; }
    public String name { get; set; } = string.Empty;
    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
}