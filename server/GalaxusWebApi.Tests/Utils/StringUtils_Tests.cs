using GalaxusWebApi.Utils;

namespace GalaxusWebApi.Tests.Utils;

public class StringUtils_Tests
{
    [Fact]
    public void ContainsLetterE_InputContainsE_ReturnsTrue()
    {
        // Arrange
        var input = "abcde";
        // Act
        var actual = StringUtils.ContainsLetterE(input);
        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData("abcd")]
    [InlineData("fghi")]
    public void ContainsLetterE_InputDoesNotContainE_ReturnsFalse(string input)
    {
        // var input = "abcd";
        var actual = StringUtils.ContainsLetterE(input);
        Assert.False(actual);
    }
}
