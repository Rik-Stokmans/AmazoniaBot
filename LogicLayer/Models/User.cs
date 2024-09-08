namespace LogicLayer.Models;

public abstract class User(ulong discordId, string minecraftUuid, string username, string password)
{
     public ulong DiscordId { get; set; } = discordId;
     public string MinecraftUuid { get; set; } = minecraftUuid;
     public string Username { get; set; } = username;
     public string Password { get; set; } = password;
}