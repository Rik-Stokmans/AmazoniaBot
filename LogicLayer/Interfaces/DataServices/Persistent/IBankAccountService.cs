using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IBankAccountService
{
    /// <summary>
    /// Retrieves a specific bank account associated with the provided Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID associated with the bank account.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="BankAccount"/>: The bank account associated with the specified Discord ID, or null if not found.
    /// </returns>
    public Task<(DatabaseResult, BankAccount)> GetBankAccount(ulong discordId);

    /// <summary>
    /// Retrieves all bank accounts stored in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{BankAccount}"/>: A list of all bank accounts in the system.
    /// </returns>
    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts();

    /// <summary>
    /// Creates a new bank account or updates an existing one in the system.
    /// </summary>
    /// <param name="bankAccount">The bank account object to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the operation.
    /// </returns>
    public Task<DatabaseResult> CreateUpdateBankAccount(BankAccount bankAccount);

    /// <summary>
    /// Deletes the bank account associated with the specified Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID associated with the bank account to delete.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the delete operation.
    /// </returns>
    public Task<DatabaseResult> DeleteBankAccount(ulong discordId);
    
    //TODO: add a transfer method to transfer funds between two bank accounts

}