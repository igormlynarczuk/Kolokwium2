namespace WebApplication1.DTOs;

public class GetCharacterDTO
{
    public int Id { get; set; }
    public String FirstName { get; set; } = null!;
    public String LastName { get; set; } = null!;
    private int CurrentWei { get; set; }
    private int MaxWeight { get; set; }
}

public class GetBackpackDTO
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public class GetCharacter_titleDTO
{
    public DateTime AcquiredAt { get; set; }
}