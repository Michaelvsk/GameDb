using Michaelvsk.GameDb.Models;
using Michaelvsk.GameDb.Models.DataAccess;

namespace Michaelvsk.GameDb.Core.Repositories;

public class GameRepositoryStatic : IGameRepository
{
    private List<Game> _games = new()
    {
        new Game()
        {
            Id = new Guid("11111111-1111-1111-1111-111111111111"),
            Title = "Super Mario Bros.",
            Description = "First title of famous Super Mario Bros. series.",
            Genre = new() {Genre.PLATFORMER},
            Platform = new() {Platform.NINTENDO_NES},
            Rating = Rating.Top,
            Cover = new Guid("11111111-1111-1111-1111-111111111112")
        },
        new Game()
        {
            Id = new Guid("21111111-1111-1111-1111-111111111111"),
            Title = "Super Metroid",
            Description = "Maybe the best game of all time.",
            Genre = new() {Genre.METROIDVANIA},
            Platform = new() {Platform.NINTENDO_SNES},
            Rating = Rating.Top,
            Cover = new Guid("21111111-1111-1111-1111-111111111112")
        }
    };

    public Game? GetGame(Guid Id) => _games.FirstOrDefault(g => g.Id == Id);

    public Task<List<Game>> GetGamesAsync()
    {
        return Task.FromResult(_games);
    }
}
