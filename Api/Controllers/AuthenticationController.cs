using LogicLayer.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("{username}/{password}/{minecraftName}/{discordId}")]
    public async Task<ActionResult> RegisterAccount(string username, string password, string minecraftName, ulong discordId)
    {
        var result = await Core.RegisterAccount(username, password, minecraftName, discordId);
        
        return result ? Ok() : BadRequest();
    }
    
    [HttpPost("{code}")]
    public async Task<ActionResult> VerifyAccount(string code)
    {
        var result = await Core.VerifyAccount(code);
        
        return result ? Ok() : BadRequest();
    }
    
    
    
}