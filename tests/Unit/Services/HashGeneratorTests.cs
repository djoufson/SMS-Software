using api.Services.Concrete;
using api.Settings;

namespace tests.Unit.Services;

public class HashGeneratorTests
{
    [Theory]
    [InlineData("PaSSw0rD!", "PaSSw0rD!", true)]
    [InlineData("PaSSw0rD", "PaSSw0rD!", false)]
    [InlineData("paSSw0rD!", "PaSSw0rD!", false)]
    public void GeneratedHashes_ShouldBeUnique(string firstPassword, string secondPassword, bool expected)
    {
        // Arrange
        var hashGenerator = new HashGenerator(new HashSettings()
        {
            Salt = "my_key_secret_host_uncle_djoufson"
        });

        // Act
        var firstHash = hashGenerator.Hash(firstPassword);
        var secondHash = hashGenerator.Hash(secondPassword);

        // Assert
        Assert.Equal(expected, firstHash == secondHash);
    }
}
