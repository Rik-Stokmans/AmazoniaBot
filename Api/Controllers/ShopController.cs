using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopController : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<ShopItem>>> GetAllShopItems()
    {
        var shopItems = await Core.GetAllShopItems();

        return Ok(shopItems);
    }
}