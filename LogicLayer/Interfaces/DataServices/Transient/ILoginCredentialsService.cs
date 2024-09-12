using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface ILoginCredentialsService
{
    public Task<(DatabaseResult, string)> StoreUserWithCode(User user);
    
    public Task<(DatabaseResult, User)> GetUserFromCode(string code);
    
    public Task<DatabaseResult> RemoveCode(string code);
}