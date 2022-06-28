using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;

using Michaelvsk.GameDb.Core.Services;
using Michaelvsk.GameDb.Models;

namespace Michaelvsk.GameDb.ViewModels;

[QueryProperty(nameof(GameId), nameof(GameId))]
public partial class GameItemViewModel : BaseViewModel
{
    [ObservableProperty]
    string _gameId;

    [ObservableProperty]
    Game _game;

    readonly IGameService _gameService;

    public GameItemViewModel(IGameService gameService)
    {
        _gameService = gameService;
    }

    async partial void OnGameIdChanged(string value)
    {
        if (Guid.TryParse(value, out var gameId))
        {
            await LoadGame(gameId);
        }
    }

    partial void OnGameChanged(Game value)
    {
        Title = Game.Title;
    }

    async Task LoadGame(Guid gameId)
    {
        var result = await _gameService.GetGameByIdAsync(gameId);
        result.Switch(
            game => Game = game,
            async nf =>
            {
                // TODO Implement l10n
                // TODO Implement a notification service
                var toast = Toast.Make("Selected game was not found. :(", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
                await Shell.Current.GoToAsync("..");
            });
    }
}
