using System.Collections.ObjectModel;
using System.Diagnostics;

using Michaelvsk.GameDb.Models;
using Michaelvsk.GameDb.Models.DataAccess;

using CommunityToolkit.Mvvm.Input;

namespace Michaelvsk.GameDb.ViewModels;
public partial class GameListViewModel : BaseViewModel
{
    public ObservableCollection<Game> Games { get; set; }

    IGameRepository _gameRepo;

    public GameListViewModel(IGameRepository gameRepository)
    {
        _gameRepo = gameRepository;
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
            var notes = await _gameRepo.GetGamesAsync();
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
