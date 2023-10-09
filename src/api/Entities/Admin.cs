using api.Entities.Base;
using api.Entities.ValueObjects;

namespace api.Entities;

public class Admin : User
{
    private Admin(string id, string firstName, string lastName, Email email, Password password, string street, string city, string zipCode, string province, string telephone, bool inactive, string personalId, string image) : base(id, firstName, lastName, email, password, street, city, zipCode, province, telephone, inactive, personalId, image)
    {
    }

    // For Entity Framework concerns
    private Admin()
    {}

    public User Create(
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
            inactive,
            personalId,
            image);
    }
}
