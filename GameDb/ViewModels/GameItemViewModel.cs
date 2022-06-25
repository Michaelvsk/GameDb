using CommunityToolkit.Mvvm.ComponentModel;

using Michaelvsk.GameDb.Models;
using Michaelvsk.GameDb.Models.DataAccess;

namespace Michaelvsk.GameDb.ViewModels;

[QueryProperty(nameof(GameId), nameof(GameId))]
public partial class GameItemViewModel : BaseViewModel
{
    [ObservableProperty]
    string _gameId;
    
    [ObservableProperty]
    Game _game;

    IGameRepository _gameRepo;
    
    public GameItemViewModel(IGameRepository gameRepo)
    {
        _gameRepo = gameRepo;    
    }

    partial void OnGameIdChanged(string value)
    {
        if (Guid.TryParse(value, out var gameId))
        {
            LoadGame(gameId);
        }
    }

    partial void OnGameChanged(Game value)
    {
        Title = Game.Title;
    }

    void LoadGame(Guid gameId)
    {
        Game = _gameRepo.GetGame(gameId);
    }
}
