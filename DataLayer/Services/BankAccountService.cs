using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace DataLayer.Services;

public class BankAccountService : IBankAccountService
{
    public (DatabaseResult, BankAccount) GetBankAccount(ulong discordId)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<BankAccount>) GetAllBankAccounts()
    {
        throw new NotImplementedException();
    }

    public DatabaseResult CreateUpdateBankAccount(BankAccount bankAccount)
    {
        throw new NotImplementedException();
    }

    public DatabaseResult DeleteBankAccount(ulong discordId)
    {
        throw new NotImplementedException();
    }
}