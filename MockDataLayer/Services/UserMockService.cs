using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class UserMockService : IUserService
{
    public Task<(DatabaseResult, User)> GetUser(ulong discordId)
    {
        var user = MockData.Users.Find(user => user.DiscordId == discordId);
        
        return Task.FromResult(user == null
            ? (DatabaseResult.NotFound, new User(0, "", "", ""))
            : (DatabaseResult.Success, user));
    }

    public Task<(DatabaseResult, User)> GetUser(string username)
    {
        var user = MockData.Users.Find(user => user.Username == username);
        
        return Task.FromResult(user == null
            ? (DatabaseResult.NotFound, new User(0, "", "", ""))
            : (DatabaseResult.Success, user));
    }

    public Task<(DatabaseResult, List<User>)> GetAllUsers()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.Users));
    }

    public Task<DatabaseResult> CreateUpdateUser(User user)
    {
        var existingUser = MockData.Users.Find(u => u.DiscordId == user.DiscordId || u.Username == user.Username);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.MinecraftName = user.MinecraftName;
            return Task.FromResult(DatabaseResult.Success);
        }

        MockData.Users.Add(user);
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> DeleteUser(ulong discordId)
    {
        var user = MockData.Users.Find(u => u.DiscordId == discordId);
        if (user == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }

        MockData.Users.Remove(user);
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<bool> UserExists(ulong discordId)
    {
        return Task.FromResult(MockData.Users.Exists(u => u.DiscordId == discordId));
    }
}