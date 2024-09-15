namespace AuthenticationLayer;

public class RequestPermissions(bool valid, bool expired, List<ulong> allowedDiscordIds)
{
    public bool Valid { get; set; } = valid;
    
    public bool Expired { get; set; } = expired;

    public List<ulong> AllowedDiscordIds { get; set; } = allowedDiscordIds;
}