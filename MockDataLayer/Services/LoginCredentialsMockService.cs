using LogicLayer.Cryptography;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;
public class LoginCredentialService : ILoginCredentialsService
{
    public Task<(DatabaseResult, string)> StoreUserWithCode(User user)
    {
        var code = Verification.GenerateVerificationCode();
        
        MockData.LoginCredentials.Add(code, new User(user.DiscordId, user.MinecraftName, user.Username, user.Password));
        
        return Task.FromResult((DatabaseResult.Success, code));
    }

    public Task<(DatabaseResult, User)> GetUserFromCode(string code)
    {
        return
            Task.FromResult(!MockData.LoginCredentials.TryGetValue(code, out var user) 
                ? 
                (DatabaseResult.NotFound, new User(0, "", "", "")) 
                : 
                (DatabaseResult.Success, user));
    }

    public Task<DatabaseResult> RemoveCode(string code)
    {
        return Task.FromResult(MockData.LoginCredentials.Remove(code) ? DatabaseResult.Success : DatabaseResult.NotFound);
    }
}
