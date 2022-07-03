using Michaelvsk.GameDb.Core.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.Core.Services;

public interface IGameService
{
    Task<List<Game>> GetGamesAsync();

    Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid gameId);
}
