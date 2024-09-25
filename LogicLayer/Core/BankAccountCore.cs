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
    /// <param name="accountName"></param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the bank account was successfully registered. 
    /// Returns <c>false</c> if the account already exists.
    /// </returns>
    public static async Task<bool> RegisterBankAccount(ulong discordId, string accountName)
    {
        CheckInit();
        
        //todo refactor this

        var allBankAccounts = await GetAllBankAccounts();

        var usersBankAccounts = allBankAccounts.Where(x => x.DiscordId == discordId).ToList();
        
        var bankAccountCount = usersBankAccounts.Count;
        
        if (bankAccountCount >= _maxBankAccounts) return false;
        
        if (usersBankAccounts.Any(ba => ba.AccountName == accountName)) return false;
        
        allBankAccounts = allBankAccounts.OrderByDescending(x => x.AccountNumber).ToList();
        
        var accountNumber = allBankAccounts.Count == 0 ? 1 : allBankAccounts[0].AccountNumber + 1;
        
        var result = await _bankAccountService.CreateBankAccount(new BankAccount(discordId, accountName, accountNumber, 0));
        
        return result == DatabaseResult.Success;
    }

    /// <summary>
    /// Changes the balance of the bank account associated with the given Discord ID.
    /// </summary>
    /// <param name="bankAccountId"></param>
    /// <param name="value">The amount to change the balance by. Can be positive or negative.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the balance was successfully updated. 
    /// Returns <c>false</c> if the account does not exist.
    /// </returns>
    public static async Task<bool> ChangeBalance(int bankAccountId, long value)
    {
        CheckInit();

        var result = await _bankAccountService.AddFunds(bankAccountId, value);
        return result == DatabaseResult.Success;
    }
    
    public static async Task<long> GetBalance(int accountNumber)
    {
        CheckInit();

        var (result, bankAccount) = await _bankAccountService.GetBankAccount(accountNumber);
        return result == DatabaseResult.Success ? bankAccount.Balance : 0;
    }
    
    public static async Task<bool> TransferBalance(ulong sender, int accountNumber, int targetAccountNumber, long amount)
    {
        CheckInit();
        
        if (amount <= 0) return false;
        
        var result = await _bankAccountService.TransferFunds(sender, accountNumber, targetAccountNumber, amount);
        
        return result == DatabaseResult.Success;
    }
    
    public static async Task<bool> TransferAllBalance(ulong sender, int accountNumber, int targetAccountNumber)
    {
        CheckInit();
        
        var result = await _bankAccountService.TransferAllFunds(sender, accountNumber, targetAccountNumber);
        
        return result == DatabaseResult.Success;
    }


    /// <summary>
    /// Deletes the bank account associated with the given Discord ID.
    /// </summary>
    /// <param name="discordId">The unique Discord ID of the user.</param>
    /// <param name="accountNumber"></param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the account was successfully deleted.
    /// </returns>
    public static async Task<bool> DeleteBankAccount(ulong discordId, int accountNumber)
    {
        CheckInit();

        var result = await _bankAccountService.DeleteBankAccount(discordId, accountNumber);
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

    public static async Task<List<BankAccount>> GetAllBankAccounts(ulong discordId)
    {
        CheckInit();

        var (result, bankAccounts) = await _bankAccountService.GetAllBankAccounts(discordId);
        return result == DatabaseResult.Success ? bankAccounts : [];
    }

    public static async Task<bool> Pay(int accountNumber, long amount)
    {
        CheckInit();

        var result = await _bankAccountService.Pay(accountNumber, amount);
        return result == DatabaseResult.Success;
    }
}