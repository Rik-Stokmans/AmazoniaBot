namespace LogicLayer.Models;

public class User(ulong discordId, string username, string password)
{
     public ulong DiscordId { get; set; } = discordId;
     //todo add minecraft UUID
     public string Username { get; set; } = username;
     public string Password { get; set; } = password;
}