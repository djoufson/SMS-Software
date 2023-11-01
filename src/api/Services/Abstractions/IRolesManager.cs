using api.Entities.Base;

namespace api.Services.Abstractions;

/// <summary>
/// This service enables to manage the Roles of a user
/// </summary>
public interface IRolesManager
{
    /// <summary>
    /// Assign a user to a specific role
    /// </summary>
    /// <param name="user">The user we want to deal with</param>
    /// <param name="role">The appropriate role we want to assign to the user</param>
    /// <returns>A boolean value representing the success status of the operation</returns>
    Task<bool> AddToRoleAsync(User user, string role);
}