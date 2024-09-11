namespace LogicLayer.Models;

/// <summary>
/// Represents the financial history of a company, including profit and dividend information.
/// </summary>
/// <param name="companyId">The unique identifier of the company.</param>
/// <param name="date">The date of the financial record.</param>
/// <param name="profit">The profit amount for the given date.</param>
/// <param name="dividendPerShare">The dividend amount per share for the given date.</param>
public class CompanyHistory(int companyId, DateTime date, int profit, double dividendPerShare)
{
    /// <summary>
    /// Gets or sets the unique identifier of the company.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the company's unique identifier.
    /// </value>
    public int CompanyId { get; set; } = companyId;

    /// <summary>
    /// Gets or sets the date of the financial record.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> representing the date of the record.
    /// </value>
    public DateTime Date { get; set; } = date;

    /// <summary>
    /// Gets or sets the profit amount for the given date.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the profit amount.
    /// </value>
    public int Profit { get; set; } = profit;

    /// <summary>
    /// Gets or sets the dividend amount per share for the given date.
    /// </summary>
    /// <value>
    /// A <see cref="double"/> representing the dividend amount per share.
    /// </value>
    public double DividendPerShare { get; set; } = dividendPerShare;
}
