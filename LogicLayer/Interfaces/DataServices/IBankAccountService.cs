using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IBankAccountService
{
    /// <summary>
    /// Retrieves all bank accounts stored in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{BankAccount}"/>: A list of all bank accounts in the system.
    /// </returns>
    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts();

    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts(ulong discordId);
        
    /// <summary>
    /// Creates a new bank account or updates an existing one in the system.
    /// </summary>
    /// <param name="bankAccount">The bank account object to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the operation.
    /// </returns>
    public Task<DatabaseResult> CreateBankAccount(BankAccount bankAccount);
    
    public Task<DatabaseResult> AddFunds(int accountNumber, long amount);
    
    public Task<DatabaseResult> TransferFunds(ulong sender, int accountNumber, int targetAccountNumber, long amount);
    public Task<DatabaseResult> TransferAllFunds(ulong sender, int accountNumber, int targetAccountNumber);

    /// <summary>
    /// Deletes the bank account associated with the specified Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID associated with the bank account to delete.</param>
    /// <param name="accountNumber"></param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the delete operation.
    /// </returns>
    public Task<DatabaseResult> DeleteBankAccount(ulong discordId, int accountNumber);
    
    //TODO: add a transfer method to transfer funds between two bank accounts

}