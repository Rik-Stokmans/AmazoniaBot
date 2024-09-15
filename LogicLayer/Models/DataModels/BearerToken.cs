namespace LogicLayer.Models.DataModels;

public class BearerToken(ulong discordId, string bearer)
{
    public ulong DiscordId { get; set; } = discordId;
    
    public string Bearer { get; set; } = bearer;
}
