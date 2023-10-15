using api.Entities;
using api.Entities.ValueObjects;
using api.Services.Concrete;
using api.Settings;

namespace tests.Unit.Entities;

public class SecretaryTests
{
    [Fact]
    public void SanctionStudent_ShouldAddTheProvidedSanctionToBothSecretaryAndStudentSanctionsLists()
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });

        var secretary = (Secretary) Secretary.Create(
            "John",
            "Doe",
            Email.Create("johndoe@email.com")!,
            Password.CreateNewPassword("john-doe1234", hashGenerator)!,
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

        var firstSanction = Sanction.Create(secretary, student, "Motif", 2000);
        var secondSanction = Sanction.Create(secretary, student, "Motif", 1000);

        // Act
        secretary.SanctionStudent(student, firstSanction);
        secretary.SanctionStudent(student, secondSanction);

        // Assert
        Assert.Equal(2, secretary.Sanctions.Count);
        Assert.Equal(2, student.Sanctions.Count);
    }
}
