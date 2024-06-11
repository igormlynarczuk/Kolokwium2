using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Character_title
{
    [Key]
    public int id;

    public String firstName;
    public String lastName;
    private int CurrentWei;
    private int MaxWeight;
}