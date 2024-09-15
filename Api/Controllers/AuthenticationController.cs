using AuthenticationLayer;
using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("RegisterAccount/{username},{password},{minecraftName},{discordId}")]
    public async Task<ActionResult> RegisterAccount(string username, string password, string minecraftName, ulong discordId)
    {
        
        
        var result = await Core.RegisterAccount(username, password, minecraftName, discordId);
        
        return result ? Ok() : BadRequest();
    }
    
    [HttpGet("Verify/{code}")]
    public async Task<ActionResult<BearerToken>> VerifyAccount(string code)
    {
        var (result, bearerToken) = await Core.VerifyAccount(code);
        
        return result ? Ok(bearerToken) : BadRequest("Code is invalid or expired.");
    }
    
    [HttpPost("Login/{username},{password}")]
    public async Task<ActionResult<BearerToken>> Login(string username, string password)
    {
        var (result, bearer) = await Core.VerifyAccount(username, password);

        return result ? Ok(bearer) : BadRequest("Invalid username or password.");
    }
    
    [HttpGet("RefreshToken/{refreshToken}")]
    public ActionResult<BearerToken> RefreshToken(string refreshToken)
    {
        var (result, bearer) = Core.RefreshToken(refreshToken);

        return result ? Ok(bearer) : BadRequest("Invalid refresh token.");
    }
}