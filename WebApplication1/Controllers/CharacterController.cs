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
    
    [HttpGet]
    public async Task<IActionResult> GetCharacterData(int characterId)
    {
        var clients = await _dbService.GetOrdersData(characterId);
        
        return Ok(orders.Select(e => new GetOrdersDTO()
        {
            Id = e.Id,
            AcceptedAt = e.AcceptedAt,
            FulfilledAt = e.FulfilledAt,
            Comments = e.Comments,
            Pastries = e.OrderPastries.Select(p => new GetOrdersPastryDTO
            {
                Name = p.Pastry.Name,
                Price = p.Pastry.Price,
                Amount = p.Amount
            }).ToList()
        }));
    }
}