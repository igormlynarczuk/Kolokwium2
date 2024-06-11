using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
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
    
    [HttpGet]
    public async Task<IActionResult> GetCharacterData(int characterId)
    {
        var characters = await _dbService.GetCharactersData(characterId);

        return Ok();
    }
    
    
    
    
    
    [HttpPost("{charactersID}/backpacks")]
    public async Task<IActionResult> AddNewOrder(int characterID, NewItemDTO newItem)
    {
        if (!await _dbService.DoesCharacterExist(clientID))
            return NotFound($"Client with given ID - {clientID} doesn't exist");

        var Item = new Item()
        {
            Id = characterID,
            EmployeeId = newItem.EmployeeID,
            AcceptedAt = newItem.AcceptedAt,
        };
    
        
        return Created("api/backpacks", new
        {
            Id = order.Id,
            order.AcceptedAt,
            order.FulfilledAt,
            order.Comments,
        });
    }
}