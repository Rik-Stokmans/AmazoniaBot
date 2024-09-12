using LogicLayer.Cryptography;
using LogicLayer.Interfaces;
using LogicLayer.Interfaces.DataServices.Transient;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    private static IUserService _userService;
    private static ILoginCredentialsService _loginCredentialsService;

    private static async  Task<bool> CreateAccount(User user)
    {
        CheckInit();
        
        return await _userService.CreateUpdateUser(user) == DatabaseResult.Success;
    }
    
    public static async Task<bool> RegisterAccount(string username, string password, string minecraftName, ulong discordId)
    {
        CheckInit();
        
        //TODO: transfer this to the authentication project
        
        var user = new User(discordId, minecraftName, username, PasswordProtector.Protect(password));
        
        //TODO make sure this code is unique
        var verificationCode = Verification.GenerateVerificationCode();
        
        var (result, code) = await _loginCredentialsService.StoreUserWithCode(user);
        
        //TODO Send verification code to user
        //TODO convert discord handle to discord id
        
        return result == DatabaseResult.Success;
    }
    
    public static async Task<bool> VerifyAccount(string code)
    {
        CheckInit();
        
        var (result, user) = await _loginCredentialsService.GetUserFromCode(code);
        
        if (result != DatabaseResult.Success) return false;
        
        await _loginCredentialsService.RemoveCode(code);
        
        return await CreateAccount(user);
    }

}