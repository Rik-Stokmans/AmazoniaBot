using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;

public class UserMockService : IUserService
{
    public (DatabaseResult, User) GetUser(ulong discordId)
    {
        var user = MockData.Users.Find(user => user.DiscordId == discordId);
        
        return user == null
            ? (DatabaseResult.NotFound, new User(0, "", "", ""))
            : (DatabaseResult.Success, user);
    }

    public (DatabaseResult, List<User>) GetAllUsers()
    {
        return (DatabaseResult.Success, MockData.Users);
    }

    public DatabaseResult CreateUpdateUser(User user)
    {
        var existingUser = MockData.Users.Find(u => u.DiscordId == user.DiscordId);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.MinecraftUuid = user.MinecraftUuid;
            return DatabaseResult.Success;
        }

        MockData.Users.Add(user);
        return DatabaseResult.Success;
    }

    public DatabaseResult DeleteUser(ulong discordId)
    {
        var user = MockData.Users.Find(u => u.DiscordId == discordId);
        if (user == null)
        {
            return DatabaseResult.NotFound;
        }

        MockData.Users.Remove(user);
        return DatabaseResult.Success;
    }
}