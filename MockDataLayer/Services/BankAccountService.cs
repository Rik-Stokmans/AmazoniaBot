using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;

public class BankAccountService : IBankAccountService
{
    public (DatabaseResult, BankAccount) GetBankAccount(ulong discordId)
    {
        var bankAccount = MockData.BankAccounts.Find(bankAccount => bankAccount.DiscordId == discordId);
        
        return bankAccount == null
            ? (DatabaseResult.NotFound, new BankAccount(0, 0))
            : (DatabaseResult.Success, bankAccount);
    }

    public (DatabaseResult, List<BankAccount>) GetAllBankAccounts()
    {
        return (DatabaseResult.Success, MockData.BankAccounts);
    }

    public DatabaseResult CreateUpdateBankAccount(BankAccount bankAccount)
    {
        var existingBankAccount = MockData.BankAccounts.Find(ba => ba.DiscordId == bankAccount.DiscordId);
        if (existingBankAccount != null)
        {
            existingBankAccount.Balance = bankAccount.Balance;
            return DatabaseResult.Success;
        }

        MockData.BankAccounts.Add(bankAccount);
        return DatabaseResult.Success;
    }

    public DatabaseResult DeleteBankAccount(ulong discordId)
    {
        var bankAccount = MockData.BankAccounts.Find(ba => ba.DiscordId == discordId);
        if (bankAccount == null)
        {
            return DatabaseResult.NotFound;
        }

        MockData.BankAccounts.Remove(bankAccount);
        return DatabaseResult.Success;
    }
}