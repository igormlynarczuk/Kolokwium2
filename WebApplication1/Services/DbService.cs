using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService: IDbService
{
    
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<GetCharacterDTO> GetCharacterAsync(int characterId)
       {
           var character = await _context.Characters
               .Include(c => c.Backpacks)
               .ThenInclude(b => b.Item)
               .Include(c => c.CharacterTitles)
               .FirstOrDefaultAsync(c => c.Id == characterId);
           if (character == null)
               return null;
           return new GetCharacterDTO
           {
               Id = character.Id,
               FirstName = character.FirstName,
               LastName = character.LastName,
               CurrentWeight = character.CurrentWeight,
               MaxWeight = character.MaxWeight,
               BackpackItems = character.Backpacks.Select(b => new GetBackpackDTO
               {
                   ItemName = b.Item.Name,
                   ItemWeight = b.Item.Weight,
                   Amount = b.Amount
               }).ToList()
           };
       }
       public async Task<List<GetBackpackDTO>> AddItemsToBackpackAsync(int characterId, List<int> itemIds)
       {
           var character = await _context.Characters
               .Include(c => c.Backpacks)
               .FirstOrDefaultAsync(c => c.Id == characterId);
           if (character == null)
               return null;
           var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();
           foreach (var item in items)
           {
               var backpackItem = character.Backpacks.FirstOrDefault(b => b.ItemId == item.Id);
               if (backpackItem == null)
               {
                   backpackItem = new Backpack
                   {
                       CharacterId = characterId,
                       ItemId = item.Id,
                       Amount = 1
                   };
                   character.Backpacks.Add(backpackItem);
               }
               else
               {
                   backpackItem.Amount++;
               }
           }
           await _context.SaveChangesAsync();
           return character.Backpacks.Select(b => new GetBackpackDTO
           {
               ItemName = b.Item.Name,
               ItemWeight = b.Item.Weight,
               Amount = b.Amount
           }).ToList();
       }

}