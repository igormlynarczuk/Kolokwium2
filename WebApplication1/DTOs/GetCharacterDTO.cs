namespace WebApplication1.DTOs;

public partial class GetCharacterDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<GetBackpackDTO> BackpackItems { get; set; } = new List<GetBackpackDTO>();
}
public partial class GetBackpackDTO
{
    public string ItemName { get; set; } = string.Empty;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}
