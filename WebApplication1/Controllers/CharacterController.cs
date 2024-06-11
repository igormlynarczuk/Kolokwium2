using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacter(int characterId)
    {
        var character = await _dbService.GetCharacterAsync(characterId);
        if (character == null)
            return NotFound();
        return Ok(character);
    }
    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, [FromBody] List<int> itemIds)
    {
        try
        {
            var updatedBackpackItems = await _dbService.AddItemsToBackpackAsync(characterId, itemIds);
            if (updatedBackpackItems == null)
                return NotFound();
            return Ok(updatedBackpackItems);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}