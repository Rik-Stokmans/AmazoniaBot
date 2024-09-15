using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IUserService
{
    /// <summary>
    /// Retrieves the details of a specific user based on the provided Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID of the user to retrieve.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="User"/>: The user object associated with the specified Discord ID, or null if not found.
    /// </returns>
    public Task<(DatabaseResult, User)> GetUser(ulong discordId);

    /// <summary>
    /// Retrieves a list of all users in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{User}"/>: A list of all users in the system.
    /// </returns>
    public Task<(DatabaseResult, List<User>)> GetAllUsers();

    /// <summary>
    /// Creates a new user or updates an existing user's information in the system.
    /// </summary>
    /// <param name="user">The user object containing the information to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the create or update operation.
    /// </returns>
    public Task<DatabaseResult> CreateUpdateUser(User user);

    /// <summary>
    /// Deletes the user associated with the specified Discord ID.
    /// </summary>
    /// <param name="discordId">The Discord ID of the user to delete.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the delete operation.
    /// </returns>
    public Task<DatabaseResult> DeleteUser(ulong discordId);
    
    public Task<bool> UserExists(ulong discordId);

}