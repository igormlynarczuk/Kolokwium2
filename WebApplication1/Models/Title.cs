using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
}