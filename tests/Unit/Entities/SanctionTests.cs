using api.Entities;
using api.Entities.ValueObjects;
using api.Services.Concrete;
using api.Settings;

namespace tests.Unit.Entities;

public class SanctionTests
{
    [Fact]
    public void SanctionPay_ShouldUpdateTheStatusToTrue()
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });
        var secretary = (Secretary)Secretary.Create(
            "John",
            "Doe",
            Email.Create("johndoe@email.com")!,
            Password.CreateNewPassword("john-doe233", hashGenerator)!,
            "street",
            "city",
            "zip-code",
            "province",
            "telephone",
            "personalId",
            "image");

        var student = (Student)Student.Create(
            null,
            "Jane",
            "Smith",
            Email.Create("janesmith@email.com")!,
            Password.CreateNewPassword("jane-smith", hashGenerator)!,
            "street",
            "city",
            "zip-code",
            "province",
            "telephone",
            "personalId",
            "image");

        // Act
        Sanction sanction = Sanction.Create(secretary, student, "Motif", 200);
        secretary.SanctionStudent(student, sanction);
        sanction.Pay();

        // Assert
        Assert.Equal(1, student.Sanctions.Count);
        Assert.Equal(1, secretary.Sanctions.Count);
        Assert.True(sanction.PaidStatus);
    }

    [Fact]
    public void SanctionRollback_ShouldUpdateTheStatusToFalse()
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });
        var secretary = (Secretary)Secretary.Create(
            "John",
            "Doe",
            Email.Create("johndoe@email.com")!,
            Password.CreateNewPassword("john-doe233", hashGenerator)!,
            "street",
            "city",
            "zip-code",
            "province",
            "telephone",
            "personalId",
            "image");

        var student = (Student)Student.Create(
            null,
            "Jane",
            "Smith",
            Email.Create("janesmith@email.com")!,
            Password.CreateNewPassword("jane-smith", hashGenerator)!,
            "street",
            "city",
            "zip-code",
            "province",
            "telephone",
            "personalId",
            "image");

        // Act
        Sanction sanction = Sanction.Create(secretary, student, "Motif", 200);
        secretary.SanctionStudent(student, sanction);
        sanction.Pay();
        sanction.Rollback();

        // Assert
        Assert.Equal(1, student.Sanctions.Count);
        Assert.Equal(1, secretary.Sanctions.Count);
        Assert.False(sanction.PaidStatus);
    }
}
