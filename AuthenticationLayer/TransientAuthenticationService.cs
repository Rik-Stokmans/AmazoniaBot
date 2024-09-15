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
        
        return (DatabaseResult.Success, user, bearer);
    }
}











