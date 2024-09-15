using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class BankAccountMockService : IBankAccountService
{
    public Task<(DatabaseResult, BankAccount)> GetBankAccount(ulong discordId)
    {
        var bankAccount = MockData.BankAccounts.Find(bankAccount => bankAccount.DiscordId == discordId);
        
        return Task.FromResult(bankAccount == null
            ? (DatabaseResult.NotFound, new BankAccount(0, 0))
            : (DatabaseResult.Success, bankAccount));
    }

    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.BankAccounts));
    }

    public Task<DatabaseResult> CreateUpdateBankAccount(BankAccount bankAccount)
    {
        var existingBankAccount = MockData.BankAccounts.Find(ba => ba.DiscordId == bankAccount.DiscordId);
        if (existingBankAccount != null)
        {
            existingBankAccount.Balance = bankAccount.Balance;
            return Task.FromResult(DatabaseResult.Success);
        }

        MockData.BankAccounts.Add(bankAccount);
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> DeleteBankAccount(ulong discordId)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.DiscordId == discordId);
        if (bankAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }

        MockData.BankAccounts.Remove(bankAccount);
        return Task.FromResult(DatabaseResult.Success);
    }
}