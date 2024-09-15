using LogicLayer.Cryptography;

namespace LogicLayer.Models.DataModels;

public class BearerToken(ulong discordId)
{
    public ulong DiscordId { get; set; } = discordId;
    
    public string Bearer { get; set; } = Verification.GenerateBearerToken();

    public string RefreshToken { get; set; } = Verification.GenerateRefreshToken();
    
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddHours(1);
    
    public DateTime RefreshExpiryDate { get; set; } = DateTime.Now.AddDays(1);
}
