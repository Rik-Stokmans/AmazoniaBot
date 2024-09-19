using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StockExchangeController : ControllerBase
{
    [HttpGet("GetBalance/{discordId},{companyId}")]
    public async Task<ActionResult<StockBalance>> GetStockBalance(ulong discordId, int companyId)
    {
        var (success, stockBalance) = await Core.GetStockBalance(discordId, companyId);

        return !success ? NotFound() : Ok(stockBalance);
    }
    
    [HttpGet("GetBalancesByDiscordId/{discordId}")]
    public async Task<ActionResult<List<StockBalance>>> GetStockBalances(ulong discordId)
    {
        var (result, stockBalances) = await Core.GetStockBalances(discordId);

        return !result ? NotFound() : Ok(stockBalances);
    }
    
    [HttpGet("GetBalancesByCompany/{companyId}")]
    public async Task<ActionResult<List<StockBalance>>> GetStockBalances(int companyId)
    {
        var (result, stockBalances) = await Core.GetStockBalances(companyId);

        return !result ? NotFound() : Ok(stockBalances);
    }
    
}