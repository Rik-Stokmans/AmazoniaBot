using LogicLayer.Core;
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
    public async Task<ActionResult<string>> VerifyAccount(string code)
    {
        var result = await Core.VerifyAccount(code);
        
        //TODO make it return a bearer token
        return result ? Ok("testok") : BadRequest("testbad");
    }
}