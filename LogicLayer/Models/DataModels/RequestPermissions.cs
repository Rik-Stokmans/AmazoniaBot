namespace AuthenticationLayer;

public class RequestPermissions(bool valid, bool expired, ulong discordId)
{
    public bool Valid { get; set; } = valid;
    
    public bool Expired { get; set; } = expired;

    public ulong DiscordId { get; set; } = discordId;

    public RequestPermissions() : this(false, true, 0) {}
}