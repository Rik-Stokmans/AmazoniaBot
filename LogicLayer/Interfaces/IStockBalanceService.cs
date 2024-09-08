using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IStockBalanceService
{
    /// <summary>
    /// Retrieves the stock balances associated with a specific Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID of the user whose stock balances are being retrieved.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{StockBalance}"/>: A list of stock balances associated with the specified Discord ID.
    /// </returns>
    public (DatabaseResult, List<StockBalance>) GetStockBalances(ulong discordId);

    /// <summary>
    /// Retrieves all stock balances for a specific company based on the provided company ID.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company whose stock balances are being retrieved.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{StockBalance}"/>: A list of stock balances associated with the specified company.
    /// </returns>
    public (DatabaseResult, List<StockBalance>) GetAllStockBalances(int companyId);

    /// <summary>
    /// Retrieves all stock balances in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{StockBalance}"/>: A list of all stock balances in the system.
    /// </returns>
    public (DatabaseResult, List<StockBalance>) GetAllStockBalances();

    /// <summary>
    /// Creates a new stock balance or updates an existing one in the system.
    /// </summary>
    /// <param name="stockBalance">The stock balance object to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the operation.
    /// </returns>
    public DatabaseResult CreateUpdateStockBalance(StockBalance stockBalance);

    /// <summary>
    /// Deletes a stock balance for a specific user and company.
    /// </summary>
    /// <param name="discordId">The Discord ID of the user whose stock balance is to be deleted.</param>
    /// <param name="companyId">The unique identifier of the company for which the stock balance is to be deleted.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the delete operation.
    /// </returns>
    public DatabaseResult DeleteStockBalance(ulong discordId, int companyId);
}