using api.Entities;
using api.Entities.ValueObjects;
using api.Services.Concrete;
using api.Settings;
using api.Utilities;

namespace tests.Unit.Entities;

public class RoleTests
{
    [Fact]
    public void AssignUser_ShouldAddTheNewUserToRoleUsersList()
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
        bool firstAssignment = secretaryRole.AssignUser(user);
        bool secondAssignment = secretaryRole.AssignUser(user);
        bool thirdAssignment = adminRole.AssignUser(user);

        // Assert
        Assert.True(firstAssignment);
        Assert.False(secondAssignment);
        Assert.True(thirdAssignment);
    }
}
