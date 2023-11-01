using api.Entities;
using api.Entities.ValueObjects;
using api.Services.Concrete;
using api.Settings;
using api.Utilities;

namespace tests.Unit.Entities;

public class UserTests
{
    [Fact]
    public void ChangePassword_ShouldUpdateThePasswordAndChangeTheInactiveStatusToFalse()
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });

        var user = Secretary.Create(
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

        // Act
        var newPassword = Password.CreateNewPassword("new-john-doe233", hashGenerator)!;
        user.ChangePassword(newPassword);

        // Assert
        Assert.Equal(user.Password, newPassword);
        Assert.False(user.Inactive);
    }

    [Fact]
    public void AssignRole_ShouldAddTheNewRoleToUserRoleList()
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });

        var user = Secretary.Create(
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

        Role secretaryRole = Role.CreateNewRole(Roles.Secretary);
        Role adminRole = Role.CreateNewRole(Roles.Admin);

        // Act
        bool firstAssignment = user.AssignRole(secretaryRole);
        bool secondAssignment = user.AssignRole(secretaryRole);
        bool thirdAssignment = user.AssignRole(adminRole);

        // Assert
        Assert.True(firstAssignment);
        Assert.False(secondAssignment);
        Assert.True(thirdAssignment);
    }
}
