using LogicLayer.Cryptography;
using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace AuthenticationLayer;

public class TransientAuthenticationService : ITransientAuthenticationService
{
    private static List<BearerToken> BearerTokens { get; } = [];

    private static List<(User, string)> UserCodes { get; } = [];
    
    public void StoreUserWithCode(User user) 
    {
        if (UserCodes.Any(x => x.Item1.DiscordId == user.DiscordId))
        {
            UserCodes.RemoveAll(x => x.Item1.DiscordId == user.DiscordId);
        }
        
        var code = Verification.GenerateVerificationCode();
        
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            Console.WriteLine($"Verification code for {user.Username}: {code}");
        }
        
        
        
        if (UserCodes.Any(x => x.Item2 == code))
        {
            UserCodes.RemoveAll(x => x.Item2 == code);
        }
        
        UserCodes.Add((user, code));
    }
    
    public (DatabaseResult, User, string) VerifyUser(string code)
    {
        var user = UserCodes.FirstOrDefault(x => x.Item2 == code).Item1;

        if (user == null)
        {
            return (DatabaseResult.NotFound, new User(0, "", "", ""), "");
        }
        
        UserCodes.RemoveAll(x => x.Item2 == code);
        
        var bearer = Verification.GenerateBearerToken();
        
        BearerTokens.Add(new BearerToken(user.DiscordId, bearer));
        
        return (DatabaseResult.Success, user, bearer);
    }
    
    public void CreateBearerToken(ulong discordId)
    {
        BearerTokens.Add(new BearerToken(discordId, Verification.GenerateBearerToken()));
    }
}











