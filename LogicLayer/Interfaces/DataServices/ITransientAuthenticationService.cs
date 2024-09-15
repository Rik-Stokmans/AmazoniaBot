using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface ITransientAuthenticationService
{
    public void StoreUserWithCode(User user);
    
    public (DatabaseResult, User, string) VerifyUser(string code);
}