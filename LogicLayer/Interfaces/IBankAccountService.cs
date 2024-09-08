using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IBankAccountService
{
    public (DatabaseResult, BankAccount) GetBankAccount(ulong discordId);
    
    public (DatabaseResult, List<BankAccount>) GetAllBankAccounts();
    
    public DatabaseResult CreateUpdateBankAccount(BankAccount bankAccount);
    
    public DatabaseResult DeleteBankAccount(ulong discordId);
}