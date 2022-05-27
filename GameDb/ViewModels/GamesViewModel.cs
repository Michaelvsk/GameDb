using System.Collections.ObjectModel;
using System.Diagnostics;

using Michaelvsk.GameDb.Models;

namespace Michaelvsk.GameDb.ViewModels;
internal class GamesViewModel : BaseViewModel
{
    public ObservableCollection<Game> Games { get; set; }

    public Command LoadItemsCommand { get; set; }

    public GamesViewModel()
    {
        Title = "Browse";
        Games = new ObservableCollection<Game>();

        LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
    }

    async Task ExecuteLoadItemsCommand()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            Games.Clear();
            //var notes = await PluralsightDataStore.GetNotesAsync();
            //foreach (var note in notes)
            //{
            //    Games.Add(note);
            //}
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
