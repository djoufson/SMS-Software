using api.Entities.Base;

namespace api.Services.Abstractions;
public interface IAuthManager
{
    Task<bool> AddToRoleAsync(User user, string role);
}