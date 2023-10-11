using api.Entities.Base;

namespace api.Entities;

public sealed class Role : Entity<string>
{
    public ICollection<User> Users { get; private set; } = new List<User>();
    public string Designation { get; private set; }
    private Role(string id, string designation) : base(id)
    {
        Designation = designation;
    }

#pragma warning disable CS8618
    // For Entity Framework concerns
    private Role()
    {}
#pragma warning restore CS8618

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
