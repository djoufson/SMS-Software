using api.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace api.Features.Users;

public partial class UserService
{
    public async Task<IEnumerable<UserResponse>> GetAllUsers(GetUsersQuery query)
    {
        IQueryable<User> usersQuery = _context.Users;
        // Filter by Active
        if(query.Active is bool active)
            usersQuery = usersQuery.Where(u => u.Inactive != active);

        var users = await usersQuery.ToArrayAsync();
        if(!users.Any())
            return Enumerable.Empty<UserResponse>();

        return users
            .Select(u => new UserResponse(
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email.Value,
                u.Street,
                u.City,
                u.ZipCode,
                u.Province,
                u.Telephone,
                u.PersonalId,
                u.Inactive,
                u.Image));
    }
}

public record GetUsersQuery(
    bool? Active
);