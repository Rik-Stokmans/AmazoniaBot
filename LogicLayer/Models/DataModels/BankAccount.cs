namespace LogicLayer.Models.DataModels;

/// <summary>
/// Represents a bank account with a balance and associated Discord ID.
/// </summary>
/// <param name="discordId">The unique Discord ID associated with the bank account.</param>
/// <param name="balance">The current balance of the bank account.</param>
public class BankAccount(ulong discordId, string accountName, int accountNumber, long balance)
{
    /// <summary>
    /// Gets or sets the current balance of the bank account.
    /// </summary>
    /// <value>
    /// A <see cref="double"/> representing the current balance.
    /// </value>
    public long Balance { get; set; } = balance;
    
    public string AccountName { get; set; } = accountName;

    public int AccountNumber { get; set; } = accountNumber;
    
    /// <summary>
    /// Gets or sets the unique Discord ID associated with the bank account.
    /// </summary>
    /// <value>
    /// A <see cref="ulong"/> representing the unique Discord ID.
    /// </value>
    public ulong DiscordId { get; set; } = discordId;

    
}
