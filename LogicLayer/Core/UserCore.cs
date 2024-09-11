using LogicLayer.Cryptography;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    private static IUserService _userService;
    private static ILoginCredentialsService _loginCredentialsService;

    private static bool CreateAccount(User user)
    {
        CheckInit();
        
        return _userService.CreateUpdateUser(user) == DatabaseResult.Success;
    }
    
    public static bool RegisterAccount(string username, string password, string passwordConfirmation, string minecraftUuid, ulong discordId)
    {
        CheckInit();
        
        if (password != passwordConfirmation) return false;
        
        var user = new User(discordId, minecraftUuid, username, PasswordProtector.Protect(password));
        
        //TODO make sure this code is unique
        var verificationCode = Verification.GenerateVerificationCode();
        
        var (result, code) = _loginCredentialsService.StoreUserWithCode(user);
        
        //TODO Send verification code to user
        //TODO convert discord handle to discord id
        
        return result == DatabaseResult.Success;
    }
    
    public static bool VerifyAccount(string code)
    {
        CheckInit();
        
        var (result, user) = _loginCredentialsService.GetUserFromCode(code);
        
        if (result != DatabaseResult.Success) return false;
        
        _loginCredentialsService.RemoveCode(code);
        
        return CreateAccount(user);
    }

}