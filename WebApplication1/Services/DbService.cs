using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService: IDbService
{
    
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Character>> GetCharactersData(int characterId)
    {
        return await _context.Characters
            .Where(e => characterId == null || e.character.Id == characterId)
            .ToListAsync();
    }
    
}