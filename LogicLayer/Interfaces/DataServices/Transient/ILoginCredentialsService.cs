using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface ILoginCredentialsService
{
    public (DatabaseResult, string) StoreUserWithCode(User user);
    
    public (DatabaseResult, User) GetUserFromCode(string code);
    
    public DatabaseResult RemoveCode(string code);
}