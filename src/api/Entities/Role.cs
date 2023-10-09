using api.Entities.Base;

namespace api.Entities;

public sealed class Role : Entity<string>
{
    public ICollection<User> Users { get; private set; } = new List<User>();
    public string Designation { get; set; } = null!;
    private Role(string id, string designation) : base(id)
    {
        Designation = designation;
    }

    // For Entity Framework concerns
    private Role()
    {}

    public static Role CreateNewRole(string designation)
    {
        return new(Guid.NewGuid().ToString(), designation);
    }

    public bool AssignUser(User user)
    {
        if(Users.Contains(user))
            return false;

        Users.Add(user);
        return true;
    }
}
