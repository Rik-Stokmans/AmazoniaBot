using LogicLayer.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RequestVerifier
{
    public static (bool, ulong) VerifyRequest(ControllerBase controller)
    {
        var permissions = Core.GetRequestPermissions(controller.Request.Headers["Bearer"].ToString());
        
        if (permissions.Expired || permissions.DiscordId == 0 || !permissions.Valid)
        {
            return (false, 0);
        }
        
        return (true, permissions.DiscordId);
    }
}