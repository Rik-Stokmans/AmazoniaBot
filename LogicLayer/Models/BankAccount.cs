namespace LogicLayer.Models;

public class BankAccount (double balance, ulong discordId)
{
    public double Balance { get; set; } = balance;
    public ulong DiscordId { get; set; } = discordId;
}