namespace Michaelvsk.GameDb.Models.Tests;
public class GameTests
{
    [Fact]
    public void Set_Null_Title_ThrowArgumentNullException()
    {
        string? title = null;
        Game game;

#pragma warning disable CS8604 // Possible null reference argument.
        Action actual = () => game = new Game(title);
#pragma warning restore CS8604 // Possible null reference argument.

        Assert.Throws<ArgumentNullException>(actual);
    }

    [Fact]
    public void Set_Empty_Title_ThrowsArgumentException()
    {
        string title = string.Empty;
        Game game;

        Action actual = () => game = new Game(title);

        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void Assign_DefaultGuid_AsCoverId_ThrowsArgumentException()
    {
        var game = new Game("title");
        var DEFAULT_GUID = Guid.Empty;

        Action actual = () => game.CoverId = DEFAULT_GUID;

        Assert.Throws<ArgumentException>(actual);
    }
}
