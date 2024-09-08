namespace LogicLayer.Models;

/// <summary>
/// Represents an abstract bank account with a balance and associated Discord ID.
/// </summary>
/// <param name="balance">The current balance of the bank account.</param>
/// <param name="discordId">The unique Discord ID associated with the bank account.</param>
public abstract class BankAccount(double balance, ulong discordId)
{
    /// <summary>
    /// Gets or sets the current balance of the bank account.
    /// </summary>
    /// <value>
    /// A <see cref="double"/> representing the current balance.
    /// </value>
    public double Balance { get; set; } = balance;

    /// <summary>
    /// Gets or sets the unique Discord ID associated with the bank account.
    /// </summary>
    /// <value>
    /// A <see cref="ulong"/> representing the unique Discord ID.
    /// </value>
    public ulong DiscordId { get; set; } = discordId;
}
