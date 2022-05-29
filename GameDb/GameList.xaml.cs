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
            _viewModel.LoadItemsCommand.Execute(null);
    }
}

