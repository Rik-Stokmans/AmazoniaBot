namespace LogicLayer.Models;

/// <summary>
/// Represents a company with a unique identifier, stock symbol, and total shares.
/// </summary>
/// <param name="id">The unique identifier of the company.</param>
/// <param name="stockSymbol">The stock symbol of the company.</param>
/// <param name="totalShares">The total number of shares issued by the company.</param>
public class Company(int id, string stockSymbol, int totalShares)
{
    /// <summary>
    /// Gets or sets the unique identifier of the company.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the company's unique identifier.
    /// </value>
    public int Id { get; set; } = id;

    /// <summary>
    /// Gets or sets the stock symbol of the company.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the company's stock symbol.
    /// </value>
    public string StockSymbol { get; set; } = stockSymbol;

    /// <summary>
    /// Gets or sets the total number of shares issued by the company.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the total number of shares.
    /// </value>
    public int TotalShares { get; set; } = totalShares;
}
