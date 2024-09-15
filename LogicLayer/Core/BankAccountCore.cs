using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IBankAccountService _bankAccountService = null!;

    /// <summary>
    /// Registers a new bank account for the user with the given Discord ID if one does not already exist.
    /// </summary>
    /// <param name="discordId">The unique Discord ID of the user.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the bank account was successfully registered. 
    /// Returns <c>false</c> if the account already exists.
    /// </returns>
    public static async Task<bool> RegisterBankAccount(ulong discordId)
    {
        CheckInit();

        var (result, bankAccount) = await _bankAccountService.GetBankAccount(discordId);
        if (result == DatabaseResult.Success) return false;
        
        await _bankAccountService.CreateUpdateBankAccount(new BankAccount(discordId, 0));
        
        return true;
    }

    /// <summary>
    /// Changes the balance of the bank account associated with the given Discord ID.
    /// </summary>
    /// <param name="discordId">The unique Discord ID of the user.</param>
    /// <param name="value">The amount to change the balance by. Can be positive or negative.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the balance was successfully updated. 
    /// Returns <c>false</c> if the account does not exist.
    /// </returns>
    public static async Task<bool> ChangeBalance(ulong discordId, double value)
    {
        CheckInit();

        var (result, bankAccount) = await _bankAccountService.GetBankAccount(discordId);
        if (result != DatabaseResult.Success) return false;

        bankAccount.Balance += value;
        await _bankAccountService.CreateUpdateBankAccount(bankAccount);
        return true;
    }

    
    //TODO: replace this with the transfer method in IBankAccountService
    public static async Task<bool> TransferBalance(ulong sender, ulong receiver, double value)
    {
        if (sender == receiver || value <= 0) return false;
        
        var (result, bankAccounts) = await _bankAccountService.GetAllBankAccounts();
        if (result != DatabaseResult.Success) return false;

        var senderAccount = bankAccounts.Find(ba => ba.DiscordId == sender);
        var receiverAccount = bankAccounts.Find(ba => ba.DiscordId == receiver);

        if (senderAccount == null || receiverAccount == null) return false;
        
        if (senderAccount.Balance < value) return false;

        senderAccount.Balance -= value;
        receiverAccount.Balance += value;

        await _bankAccountService.CreateUpdateBankAccount(senderAccount);
        await _bankAccountService.CreateUpdateBankAccount(receiverAccount);
        return true;
    }
    

    /// <summary>
    /// Deletes the bank account associated with the given Discord ID.
    /// </summary>
    /// <param name="discordId">The unique Discord ID of the user.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the account was successfully deleted.
    /// </returns>
    public static async Task<bool> DeleteBankAccount(ulong discordId)
    {
        CheckInit();

        var result = await _bankAccountService.DeleteBankAccount(discordId);
        return result == DatabaseResult.Success;
    }

    /// <summary>
    /// Retrieves all existing bank accounts.
    /// </summary>
    /// <returns>
    /// A list of <see cref="BankAccount"/> objects representing all bank accounts, or an empty list if the retrieval fails.
    /// </returns>
    public static async Task<List<BankAccount>> GetAllBankAccounts()
    {
        CheckInit();

        var (result, bankAccounts) = await _bankAccountService.GetAllBankAccounts();
        return result == DatabaseResult.Success ? bankAccounts : [];
    }
}