using System.Collections.ObjectModel;
using System.Diagnostics;

using Michaelvsk.GameDb.Models;

using CommunityToolkit.Mvvm.Input;
using Michaelvsk.GameDb.Core.Services;

namespace Michaelvsk.GameDb.ViewModels;
public partial class GameListViewModel : BaseViewModel
{
    public ObservableCollection<Game> Games { get; set; }

    readonly IGameService _gameService;

    public GameListViewModel(IGameService gameService)
    {
        _gameService = gameService;
        Title = "Browse";
        Games = new ObservableCollection<Game>();
    }

    [RelayCommand]
    async Task LoadGames()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            Games.Clear();
            var notes = await _gameService.GetGamesAsync();
            foreach (var note in notes)
            {
                Games.Add(note);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
