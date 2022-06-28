
using CommunityToolkit.Diagnostics;

using Michaelvsk.GameDb.Core.Errors;
using Michaelvsk.GameDb.Core.Repositories;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.Core.Services;

public class GameService : IGameService
{
    IGameRepository _gameRepo;

    public GameService(IGameRepository gameRepo)
    {
        Guard.IsNotNull(gameRepo);
        _gameRepo = gameRepo;
    }

    public Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid gameId)
    {
        return _gameRepo.GetGameByIdAsync(gameId);
    }

    public Task<List<Game>> GetGamesAsync()
    {
        return _gameRepo.GetGamesAsync();
    }
}
