using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class BankAccountMockService : IBankAccountService
{
    public Task<(DatabaseResult, BankAccount)> GetBankAccount(ulong discordId)
    {
        var bankAccount = MockData.BankAccounts.Find(bankAccount => bankAccount.DiscordId == discordId);
        
        return Task.FromResult(bankAccount == null
            ? (DatabaseResult.NotFound, new BankAccount(0, "", 0, 0))
            : (DatabaseResult.Success, bankAccount));
    }

    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.BankAccounts));
    }

    public Task<(DatabaseResult, BankAccount)> GetBankAccount(long accountNumber)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        
        return Task.FromResult(bankAccount == null
            ? (DatabaseResult.NotFound, new BankAccount(0, "", 0, 0))
            : (DatabaseResult.Success, bankAccount));
    }
    
    public Task<DatabaseResult> Pay(int accountNumber, long amount)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        if (bankAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }

        if (bankAccount.Balance < amount)
        {
            return Task.FromResult(DatabaseResult.Fail);
        }

        bankAccount.Balance -= amount;
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> CreateBankAccount(BankAccount bankAccount)
    {
        MockData.BankAccounts.Add(bankAccount);
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> AddFunds(int accountNumber, long amount)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        if (bankAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }

        bankAccount.Balance += amount;
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> TransferFunds(ulong sender, int accountNumber, int targetAccountNumber, long amount)
    {
        var sourceAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        var targetAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == targetAccountNumber);
        
        if (sourceAccount == null || targetAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }
        
        if (sourceAccount.DiscordId != sender)
        {
            return Task.FromResult(DatabaseResult.Unauthorized);
        }
        
        if (sourceAccount.Balance < amount)
        {
            return Task.FromResult(DatabaseResult.Fail);
        }
        
        sourceAccount.Balance -= amount;
        targetAccount.Balance += amount;
        
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> TransferAllFunds(ulong sender, int accountNumber, int targetAccountNumber)
    {
        var sourceAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        var targetAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == targetAccountNumber);
        
        if (sourceAccount == null || targetAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }
        
        if (sourceAccount.DiscordId != sender)
        {
            return Task.FromResult(DatabaseResult.Unauthorized);
        }
        
        if (sourceAccount.Balance == 0)
        {
            return Task.FromResult(DatabaseResult.Fail);
        }
        
        targetAccount.Balance += sourceAccount.Balance;
        sourceAccount.Balance = 0;
        
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> DeleteBankAccount(ulong discordId, int accountNumber)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.AccountNumber == accountNumber);
        if (bankAccount == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }
        
        if (bankAccount.DiscordId != discordId)
        {
            return Task.FromResult(DatabaseResult.Unauthorized);
        }
        
        if (bankAccount.Balance != 0)
        {
            return Task.FromResult(DatabaseResult.Fail);
        }

        MockData.BankAccounts.Remove(bankAccount);
        return Task.FromResult(DatabaseResult.Success);
    }
    
    public Task<(DatabaseResult, List<BankAccount>)> GetAllBankAccounts(ulong discordId)
    {
        var bankAccounts = MockData.BankAccounts.FindAll(ba => ba.DiscordId == discordId);
        return Task.FromResult(bankAccounts.Count == 0
            ? (DatabaseResult.NotFound, new List<BankAccount>())
            : (DatabaseResult.Success, bankAccounts));
    }
}