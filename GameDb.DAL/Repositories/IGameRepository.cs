using Michaelvsk.GameDb.Common.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.DAL.Repositories;

public interface IGameRepository
{
    Task<List<Game>> GetGamesAsync();
    Task<OneOf<Game, NotFound>> GetGameByIdAsync(Guid id);
}
