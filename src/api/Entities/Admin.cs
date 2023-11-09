using api.Entities.Base;
using api.Entities.ValueObjects;
using api.Utilities;

namespace api.Entities;

public class Admin : User
{
    private Admin(
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
        string personalId,
        string? image) : base(id, firstName, lastName, email, password, street, city, zipCode, province, telephone, personalId, image)
    {
    }

    // For Entity Framework concerns
    private Admin()
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
        string personalId,
        string? image)
    {
        return new Admin(
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
            personalId,
            image);
    }
}
