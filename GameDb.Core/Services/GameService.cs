using CommunityToolkit.Diagnostics;

using Michaelvsk.GameDb.Common.Errors;
using Michaelvsk.GameDb.DAL.Repositories;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.Core.Services;

public class GameService : IGameService
{
    readonly IGameRepository _gameRepo;
    readonly ICoverRepository _coverRepo;

    public GameService(IGameRepository gameRepo, ICoverRepository coverRepo)
    {
        Guard.IsNotNull(gameRepo);
        Guard.IsNotNull(coverRepo);

        _gameRepo = gameRepo;
        _coverRepo = coverRepo;
    }

    public async Task<OneOf<Tuple<Game, Cover?>, NotFound>> GetGameByIdAndCoverAsync(Guid gameId)
    {
        var game = await GetGameByIdAsync(gameId);
        if (game.IsT0)
        {
            if (game.AsT0.CoverId != null)
            {
                var cover = await _coverRepo.GetCoverByIdAsync((Guid)game.AsT0.CoverId);
                return cover.Match<OneOf<Tuple<Game, Cover?>, NotFound>>(
                    cover => new Tuple<Game, Cover?>(game.AsT0, cover),
                    NotFound =>
                    {
                        // TODO: log failed cover retrieval
                        return new Tuple<Game, Cover?>(game.AsT0, null);
                    }
                    );
            }
            else
            {
                return new Tuple<Game, Cover?>(game.AsT0, null);
            }
        }

        return game.AsT1;
    }

    public Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid gameId)
    {
        Guard.IsNotDefault(gameId);

        return _gameRepo.GetGameByIdAsync(gameId);
    }

    public Task<List<Game>> GetGamesAsync()
    {
        return _gameRepo.GetGamesAsync();
    }
}
