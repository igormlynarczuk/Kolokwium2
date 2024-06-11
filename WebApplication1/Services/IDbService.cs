using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IDbService
{
    public Task<ICollection<Character>> GetCharactersData(int characterId);
}