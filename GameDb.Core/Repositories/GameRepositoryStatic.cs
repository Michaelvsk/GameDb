using Michaelvsk.GameDb.Core.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.Core.Repositories;

public class GameRepositoryStatic : IGameRepository
{
    List<Game> _games = new()
    {
        new Game("Super Mario Bros.")
        {
            Description = "First title of famous Super Mario Bros. series.",
            Genre = new() {Genre.PLATFORMER},
            Platform = new() {Platform.NINTENDO_NES},
            Rating = Rating.Top,
            CoverId = new Guid("11111111-1111-1111-1111-111111111112")
        },
        new Game("Super Metroid")
        {
            Description = "Maybe the best game of all time.",
            Genre = new() {Genre.METROIDVANIA},
            Platform = new() {Platform.NINTENDO_SNES},
            Rating = Rating.Top,
            CoverId = new Guid("21111111-1111-1111-1111-111111111112")
        }
    };

    public async Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid Id)
    {
        var game = await Task.Run(() => _games.FirstOrDefault(g => g.Id == Id));

        if (game != null) return game;
        
        return new NotFound("Game with specified Id not found.");
    }

    public Task<List<Game>> GetGamesAsync()
    {
        return Task.FromResult(_games);
    }
}
