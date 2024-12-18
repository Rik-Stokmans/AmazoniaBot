using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StockExchangeController : ControllerBase
{
    [HttpGet("GetStockOrders")]
    public async Task<ActionResult<List<StockOrder>>> GetStockOrders()
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var (success, stockOrders) = await Core.GetStockOrders(user);

        return success ? Ok(stockOrders) : NotFound();
    }
    
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
    
    [HttpPost("RegisterStockOrder/{companyId},{shareAmount},{buyType},{price},{bankAccountId}")]
    public async Task<ActionResult> RegisterStockOrder(int companyId, int shareAmount, bool buyType, long price, int bankAccountId)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");
        
        var order = new StockOrder(user, companyId, shareAmount, buyType, price, bankAccountId);
        
        var success = await Core.RegisterStockOrder(order);

        return success ? Ok() : BadRequest();
    }
    
    [HttpDelete("CancelStockOrder/{stockOrderId}")]
    public async Task<ActionResult> DeleteStockOrder(int stockOrderId)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var success = await Core.CancelStockOrder(user, stockOrderId);

        return success ? Ok() : NotFound();
    }
    
}