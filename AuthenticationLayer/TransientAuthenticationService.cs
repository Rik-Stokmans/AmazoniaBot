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
    
    public (DatabaseResult, User, BearerToken?) VerifyUser(string code)
    {
        var user = UserCodes.FirstOrDefault(x => x.Item2 == code).Item1;

        if (user == null)
        {
            return (DatabaseResult.NotFound, new User(0, "", "", ""), null);
        }
        
        UserCodes.RemoveAll(x => x.Item2 == code);

        var bearer = new BearerToken(user.DiscordId);
        
        BearerTokens.Add(bearer);
        
        return (DatabaseResult.Success, user, bearer);
    }
    
    public BearerToken GenerateBearerToken(ulong discordId)
    {
        BearerTokens.RemoveAll(x => x.DiscordId == discordId);
        
        var bearer = new BearerToken(discordId);
        
        BearerTokens.Add(bearer);
        
        Console.WriteLine(BearerTokens.Count);
        
        return bearer;
    }
    
    public (bool, BearerToken?) RefreshBearerToken(string refreshToken)
    {
        var token = BearerTokens.FirstOrDefault(x => x.RefreshToken == refreshToken);
        
        if (token == null)
        {
            return (false, null);
        }
        
        if (token.RefreshExpiryDate < DateTime.Now)
        {
            BearerTokens.RemoveAll(x => x.RefreshToken == refreshToken);
            return (false, null);
        }
        
        
        BearerTokens.RemoveAll(x => x.RefreshToken == refreshToken);
        
        var newBearer = GenerateBearerToken(token.DiscordId);
        
        return (true, newBearer);
    }
    
    public RequestPermissions GetRequestPermissions(string bearer)
    {
        var token = BearerTokens.FirstOrDefault(x => x.Bearer == bearer);
        
        if (token == null)
        {
            return new RequestPermissions();
        }
        
        var now = DateTime.Now;
        var valid = token.RefreshExpiryDate > now;
        var expired = token.ExpiryDate < now;

        var discordId = token.DiscordId;
        
        return new RequestPermissions(valid, expired, discordId);
    }
}











