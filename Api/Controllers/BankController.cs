using AuthenticationLayer;
using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<BankAccount>>> GetAllBankAccounts()
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var result = await Core.GetAllBankAccounts(user);

        return Ok(result);
    }
    
    [HttpPost("Register/{name}")]
    public async Task<ActionResult> RegisterBankAccount(string name)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var result = await Core.RegisterBankAccount(user, name);

        return result ? Ok("Account Created!") : BadRequest("Bank account already exists or maximum bank accounts reached.");
    }
    
    [HttpPost("Transfer/{from},{to},{amount}")]
    public async Task<ActionResult> TransferFunds(int from, int to, long amount)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var result = await Core.TransferBalance(user, from, to, amount);

        return result ? Ok("Funds transferred!") : BadRequest("Insufficient funds or invalid account numbers.");
    }
    
    [HttpPost("TransferAll/{from},{to}")]
    public async Task<ActionResult> TransferFunds(int from, int to)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var result = await Core.TransferAllBalance(user, from, to);

        return result ? Ok("Funds transferred!") : BadRequest("Account already empty or invalid account numbers.");
    }
    
    [HttpDelete("Delete/{accountNumber}")]
    public async Task<ActionResult> DeleteBankAccount(int accountNumber)
    {
        var (verified, user) = RequestVerifier.VerifyRequest(this);
        
        if (!verified) return BadRequest("Bearer token is invalid.");

        var result = await Core.DeleteBankAccount(user, accountNumber);

        return result ? Ok("Account deleted!") : BadRequest("Account not found.");
    }
}