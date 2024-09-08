namespace LogicLayer.Models;

public class StockBalance(ulong discordId, int companyId, int shareAmount)
{
    public ulong DiscordId { get; set; } = discordId;
    public int CompanyId { get; set; } = companyId;
    public int ShareAmount { get; set; } = shareAmount;
}