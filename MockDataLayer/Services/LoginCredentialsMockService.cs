using LogicLayer.Cryptography;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;
public class LoginCredentialService : ILoginCredentialsService
{
    public (DatabaseResult, string) StoreUserWithCode(User user)
    {
        var code = Verification.GenerateVerificationCode();
        
        MockData.LoginCredentials.Add(code, new User(user.DiscordId, user.MinecraftUuid, user.Username, user.Password));
        
        return (DatabaseResult.Success, code);
    }

    public (DatabaseResult, User) GetUserFromCode(string code)
    {
        return
            !MockData.LoginCredentials.TryGetValue(code, out var user) 
            ? 
            (DatabaseResult.NotFound, new User(0, "", "", "")) 
            : 
            (DatabaseResult.Success, user);
    }

    public DatabaseResult RemoveCode(string code)
    {
        return MockData.LoginCredentials.Remove(code) ? DatabaseResult.Success : DatabaseResult.NotFound;
    }
}
