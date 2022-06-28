using Michaelvsk.GameDb.Core.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.Core.Repositories;

public interface IGameRepository
{
    Task<List<Game>> GetGamesAsync();
    Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid id);
}
