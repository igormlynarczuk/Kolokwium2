using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Items
{
    [Key]
    public int id;

    public String name;
    public int weight;
}