using Michaelvsk.GameDb.Models;

namespace Michaelvsk.GameDb.Core.DataAccess;

interface IGameRepository
{
    IList<Game> GetGames();
    Game GetGame(Guid Id);
}
