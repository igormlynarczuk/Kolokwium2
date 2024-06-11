using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Item
{
    [Key]
    public int id { get; set; }

    [MaxLength(100)]
    public String name { get; set; } = string.Empty;
    public int weight { get; set; }
    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}