using api.Entities.ValueObjects;

namespace api.Entities.Base;

public abstract class User : Entity<string>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string Province { get; private set; }
    public string Telephone { get; private set; }
    public bool Inactive { get; private set; }
    public string PersonalId { get; private set; }
    public string Image { get; private set; }
    public ICollection<Role> Roles { get; protected set; } = new List<Role>();

    protected User(
        string id,
        string firstName,
        string lastName,
        Email email,
        Password password,
        string street,
        string city,
        string zipCode,
        string province,
        string telephone,
        bool inactive,
        string personalId,
        string image) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Street = street;
        City = city;
        ZipCode = zipCode;
        Province = province;
        Telephone = telephone;
        Inactive = inactive;
        PersonalId = personalId;
        Image = image;
    }

    #pragma warning disable CS8618
    protected User()
    {}
    #pragma warning restore CS8618

    public bool ChangePassword(Password password)
    {
        Password = password;
        return true;
    }

    public bool AssignRole(Role role)
    {
        if (Roles.Contains(role))
            return false;
        Roles.Add(role);
        return true;
    }
}
