namespace Michaelvsk.GameDb.Models.DataAccess;

public interface IGameRepository
{
    Task<List<Game>> GetGamesAsync();
    Game? GetGame(Guid Id);
}
