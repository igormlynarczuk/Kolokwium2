using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Item
{
    [Key]
    public int id;

    public String name;
    public int weight;
    public ICollection<Backpack> Orders { get; set; } = new HashSet<Backpack>();
}