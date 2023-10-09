using api.Entities.Base;
using api.Entities.ValueObjects;

namespace api.Entities;

public sealed class Parent : User
{
    public ICollection<Student> Children { get; set; } = new List<Student>();
    private Parent(
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
        string image) : base(id, firstName, lastName, email, password, street, city, zipCode, province, telephone, inactive, personalId, image)
    {
    }

    // For Entity Framework concerns
    private Parent()
    {}

    public static User Create(
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
        string image)
    {
        return new Parent(
            Guid.NewGuid().ToString(),
            firstName,
            lastName,
            email,
            password,
            street,
            city,
            zipCode,
            province,
            telephone,
            inactive,
            personalId,
            image);
    }
}
