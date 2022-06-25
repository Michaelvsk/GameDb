using Michaelvsk.GameDb.Models;
using Michaelvsk.GameDb.Pages;
using Michaelvsk.GameDb.ViewModels;

namespace Michaelvsk.GameDb;

public partial class GameList : ContentPage
{
    GameListViewModel _viewModel;

    public GameList(GameListViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.Games.Count == 0)
            _viewModel.LoadGamesCommand.Execute(null);
    }

    async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var game = e.SelectedItem as Game;

        var gameDetailRoute = $"{nameof(GameDetailPage)}?GameId={game.Id}";
        await Shell.Current.GoToAsync(gameDetailRoute);
    }
}

