using Michaelvsk.GameDb.Common.Errors;
using Michaelvsk.GameDb.Core.Services;
using Michaelvsk.GameDb.DAL.Repositories;

using NSubstitute;

namespace Michaelvsk.GameDb.Test.Core.Services;
public class GameServiceTest
{
    #region GetGameByIdAndCoverAsync
    [Fact]
    public async void GetGameByIdAndCoverAsync_WithKnownGameIdAndCoverId_Returns_GameAndCover()
    {
        var superMarioBrosId = new Guid("11111111-1111-1111-1111-111111111111");
        var gameRepo = new GameRepositoryStatic();
        var coverRepo = new CoverRepositoryInMemory();
        var sut = new GameService(gameRepo, coverRepo);
        
        var gameAndCover = await sut.GetGameByIdAndCoverAsync(superMarioBrosId);


        Assert.NotNull(gameAndCover.AsT0);
        Assert.NotNull(gameAndCover.AsT0.Item1);
        Assert.NotNull(gameAndCover.AsT0.Item2);
    }
    #endregion

    #region GetGameByIdAsync
    [Fact]
    public async void GetGameByIdAsync_WithEmptyGuid_Throws_ArgumentException()
    {
        var gameRepoMock = Substitute.For<IGameRepository>();
        var coverRepoMock = Substitute.For<ICoverRepository>();
        var sut = new GameService(gameRepoMock, coverRepoMock);

        var actual = () => sut.GetGameByIdAsync(Guid.Empty);

        await Assert.ThrowsAsync<ArgumentException>(actual);
    }

    [Fact]
    public async void GetGameByIdAsync_WithKnownGameId_Returns_Game()
    {
        var gameId = new Guid("11111111-1111-1111-1111-111111111111");
        var expected = new Game(gameId, "Test Game");

        var gameRepoMock = Substitute.For<IGameRepository>();
        var coverRepoMock = Substitute.For<ICoverRepository>();
        var sut = new GameService(gameRepoMock, coverRepoMock);

        gameRepoMock.GetGameByIdAsync(gameId).Returns(expected);

        var actual = await sut.GetGameByIdAsync(gameId);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetGameByIdAsync_WithUnknownGameId_Returns_Game()
    {
        var gameId = new Guid("99999999-9999-9999-9999-999999999999");
        var expected = new NotFound("Doesn't matter");

        var gameRepoMock = Substitute.For<IGameRepository>();
        var coverRepoMock = Substitute.For<ICoverRepository>();
        var sut = new GameService(gameRepoMock, coverRepoMock);

        gameRepoMock.GetGameByIdAsync(gameId).Returns(expected);

        var actual = await sut.GetGameByIdAsync(gameId);

        Assert.Same(expected, actual.AsT1);
    }
    #endregion

    #region GetGamesAsync
    public static IEnumerable<object[]> GetGames()
    {
        yield return new Game[] { new Game("Test Game 1"), new Game("Test Game 2"), new Game("Test Game 3") };
    }

    [Theory]
    [InlineData()]
    [MemberData(nameof(GetGames))]
    public async void GetGamesAsync_Returns_RepoContent(params Game[] expected)
    {
        var gameRepoMock = Substitute.For<IGameRepository>();
        var coverRepoMock = Substitute.For<ICoverRepository>();
        var sut = new GameService(gameRepoMock, coverRepoMock);

        gameRepoMock.GetGamesAsync().Returns(expected.ToList());

        var actual = await sut.GetGamesAsync();

        Assert.Equal(expected, actual);
    }
    #endregion
}
