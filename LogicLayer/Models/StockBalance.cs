namespace LogicLayer.Models;

/// <summary>
/// Represents the stock balance for a user in a specific company.
/// </summary>
/// <param name="discordId">The unique Discord ID of the user.</param>
/// <param name="companyId">The unique identifier of the company.</param>
/// <param name="shareAmount">The number of shares the user holds in the company.</param>
public class StockBalance(ulong discordId, int companyId, int shareAmount)
{
    /// <summary>
    /// Gets or sets the Discord ID of the user.
    /// </summary>
    /// <value>
    /// A <see cref="ulong"/> representing the user's unique Discord ID.
    /// </value>
    public ulong DiscordId { get; set; } = discordId;

    /// <summary>
    /// Gets or sets the company ID where the stock balance is held.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the unique identifier of the company.
    /// </value>
    public int CompanyId { get; set; } = companyId;

    /// <summary>
    /// Gets or sets the amount of shares the user holds in the company.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the number of shares the user holds.
    /// </value>
    public int ShareAmount { get; set; } = shareAmount;
}
