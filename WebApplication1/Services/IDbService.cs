using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<GetCharacterDTO> GetCharacterAsync(int characterId);
    Task<List<GetBackpackDTO>> AddItemsToBackpackAsync(int characterId, List<int> itemIds);
}