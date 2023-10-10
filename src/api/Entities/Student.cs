using api.Entities.Base;
using api.Entities.ValueObjects;

namespace api.Entities;

public sealed class Student : User
{
    public Parent? Parent { get; private set; }
    public ICollection<Sanction> Sanctions { get; private set; } = new List<Sanction>();
    private Student(
        string id,
        Parent? parent,
        string firstName,
        string lastName,
        Email email,
        Password password,
        string street,
        string city,
        string zipCode,
        string province,
        string telephone,
        string personalId,
        string image) : base(id, firstName, lastName, email, password, street, city, zipCode, province, telephone, personalId, image)
    {
        Parent = parent;
    }

    // For Entity Framework concerns
    private Student()
    {}

    public static User Create(
        Parent? parent,
        string firstName,
        string lastName,
        Email email,
        Password password,
        string street,
        string city,
        string zipCode,
        string province,
        string telephone,
        string personalId,
        string image)
    {
        return new Student(
            Guid.NewGuid().ToString(),
            parent,
            firstName,
            lastName,
            email,
            password,
            street,
            city,
            zipCode,
            province,
            telephone,
            personalId,
            image);
    }
}
