using AuthenticationLayer;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface ITransientAuthenticationService
{
    public void StoreUserWithCode(User user);
    
    public (DatabaseResult, User, BearerToken?) VerifyUser(string code);

    public (bool, BearerToken?) RefreshBearerToken(string refreshToken);
    
    public BearerToken GenerateBearerToken(ulong discordId);

    public RequestPermissions GetRequestPermissions(string bearer);
}