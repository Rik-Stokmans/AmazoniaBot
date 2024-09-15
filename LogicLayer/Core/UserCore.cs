using LogicLayer.Cryptography;
using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IUserService _userService;
    private static ITransientAuthenticationService _transientAuthenticationService;

    private static async Task<bool> CreateAccount(User user)
    {
        CheckInit();
        
        return await _userService.CreateUpdateUser(user) == DatabaseResult.Success;
    }
    
    public static async Task<bool> RegisterAccount(string username, string password, string minecraftName, ulong discordId)
    {
        CheckInit();
        
        var user = new User(discordId, minecraftName, username, PasswordProtector.Protect(password));
        
        var userExists = await _userService.UserExists(discordId);
        
        if (userExists) return false;
        
        _transientAuthenticationService.StoreUserWithCode(user);
        
        //TODO Send verification code to user
        //TODO convert discord handle to discord id
        
        return true;
    }
    
    public static async Task<(bool, string)> VerifyAccount(string code)
    {
        CheckInit();
        
        var (result, user, bearer) = _transientAuthenticationService.VerifyUser(code);
        
        return result != DatabaseResult.Success ? (false, "") : (await CreateAccount(user), bearer);
    }

}