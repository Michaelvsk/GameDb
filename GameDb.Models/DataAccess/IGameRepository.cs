namespace Michaelvsk.GameDb.Models.DataAccess;

interface IGameRepository
{
    IList<Game> GetGames();
    Game GetGame(Guid Id);
}
