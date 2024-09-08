using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace DataLayer.Services;

public class UserServer : IUserServer
{
    public (DatabaseResult, User) GetUser(ulong discordId)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<User>) GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public DatabaseResult CreateUpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public DatabaseResult DeleteUser(ulong discordId)
    {
        throw new NotImplementedException();
    }
}