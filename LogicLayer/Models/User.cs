namespace LogicLayer.Models;

/// <summary>
/// Represents a user with a Discord ID, Minecraft UUID, username, and password.
/// </summary>
/// <param name="discordId">The unique Discord ID of the user.</param>
/// <param name="minecraftUuid">The unique Minecraft UUID of the user.</param>
/// <param name="username">The username of the user.</param>
/// <param name="password">The password of the user.</param>
public class User(ulong discordId, string minecraftUuid, string username, string password)
{
    /// <summary>
    /// Gets or sets the Discord ID of the user.
    /// </summary>
    /// <value>
    /// A <see cref="ulong"/> representing the user's unique Discord ID.
    /// </value>
    public ulong DiscordId { get; set; } = discordId;

    /// <summary>
    /// Gets or sets the Minecraft UUID of the user.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the user's unique Minecraft UUID.
    /// </value>
    public string MinecraftUuid { get; set; } = minecraftUuid;

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the user's username.
    /// </value>
    public string Username { get; set; } = username;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the user's password.
    /// </value>
    public string Password { get; set; } = password;
}
