using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IUserService
{
    public (DatabaseResult, User) GetUser(ulong discordId);
    
    public (DatabaseResult, List<User>) GetAllUsers();
    
    public DatabaseResult CreateUpdateUser(User user);
    
    public DatabaseResult DeleteUser(ulong discordId);
}